using FluentValidation.Results;
using HousesPapon.Communication.Requests.Tenants;
using HousesPapon.Communication.Responses.Tenants;
using HousesPapon.Domain.Entities;
using HousesPapon.Domain.Repositories.CommomUtilities;
using HousesPapon.Domain.Repositories.House;
using HousesPapon.Domain.Repositories.Tenant;
using HousesPapon.Exception;
using HousesPapon.Exception.Resources;

namespace HousesPapon.Application.UseCases.Tenants.Create
{
    public class CreateTenantUseCase : ICreateTenantUseCase
    {
        private readonly IReadOnlyExistenceCheckerRepository _existenceCheckerRepository;
        private readonly ITenantWriteOnlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateTenantUseCase(ITenantWriteOnlyRepository repository, IUnitOfWork unitOfWork, IReadOnlyExistenceCheckerRepository existenceCheckerRepository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _existenceCheckerRepository = existenceCheckerRepository;
        }

        public async Task<ResponseCreateTenant> Execute(RequestTenant request)
        {
            await Validate(request);
            var tenant = new Tenant
            {
                Name = request.Name,
                CreatedAt = DateTime.UtcNow,
                EntranceDate = request.EntranceDate,
                PayDay = request.PayDay,
                HouseId = request.HouseId,
            };
            tenant.IsInDebit = tenant.PayDay.Date < DateTime.UtcNow.Date;

            await _repository.Add(tenant);
            await _unitOfWork.Commit();

            return new ResponseCreateTenant
            {
                Id = tenant.Id,
                Name = tenant.Name,
                PayDay = tenant.PayDay,
                CreatedAt = tenant.CreatedAt,
                EntranceDate = tenant.EntranceDate,
                IsInDebit = tenant.IsInDebit,
                HouseId = tenant.HouseId
            };
        }

        private async Task Validate(RequestTenant request)
        {
            var result = new TenantValidator().Validate(request);

            var houseExist = await _existenceCheckerRepository.HouseExist(request.HouseId);
            if (!houseExist)
                result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.HOUSE_NOT_FOUND));

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}

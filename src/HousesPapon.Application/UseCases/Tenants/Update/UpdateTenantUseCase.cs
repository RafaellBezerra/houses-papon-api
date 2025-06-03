using FluentValidation.Results;
using HousesPapon.Communication.Requests.Tenants;
using HousesPapon.Domain.Repositories.CommomUtilities;
using HousesPapon.Domain.Repositories.House;
using HousesPapon.Domain.Repositories.Tenant;
using HousesPapon.Exception;
using HousesPapon.Exception.Resources;

namespace HousesPapon.Application.UseCases.Tenants.Update
{
    public class UpdateTenantUseCase : IUpdateTenantUseCase
    {
        private readonly ITenantUpdateOnlyRepository _repository; 
        private readonly IReadOnlyExistenceCheckerRepository _existenceCheckerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateTenantUseCase(ITenantUpdateOnlyRepository repository, IUnitOfWork unitOfWork, IReadOnlyExistenceCheckerRepository existenceCheckerRepository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _existenceCheckerRepository = existenceCheckerRepository;
        }

        public async Task Execute(RequestTenant request, long Id)
        {
            await Validate(request);

            var tenant = await _repository.GetById(Id) ?? throw new NotFoundException(ResourceErrorMessages.TENANT_NOT_FOUND);

            tenant.Name = request.Name;
            tenant.EntranceDate = request.EntranceDate;
            tenant.PayDay = request.PayDay;
            tenant.HouseId = request.HouseId;
            tenant.IsInDebit = request.PayDay.Date < DateTime.UtcNow.Date;

            _repository.Update(tenant);
            await _unitOfWork.Commit();
            
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

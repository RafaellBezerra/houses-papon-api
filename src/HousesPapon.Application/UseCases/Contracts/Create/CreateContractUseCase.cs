using FluentValidation.Results;
using HousesPapon.Communication.Requests.Contracts;
using HousesPapon.Communication.Responses.Contracts;
using HousesPapon.Domain.Entities;
using HousesPapon.Domain.Repositories.CommomUtilities;
using HousesPapon.Domain.Repositories.Contract;
using HousesPapon.Exception;
using HousesPapon.Exception.Resources;

namespace HousesPapon.Application.UseCases.Contracts.Create
{
    public class CreateContractUseCase : ICreateContractUseCase
    {
        private readonly IContractWriteOnlyRepository _repository;
        private readonly IReadOnlyExistenceCheckerRepository _existenceCheckerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateContractUseCase(IContractWriteOnlyRepository repository, IUnitOfWork unitOfWork, IReadOnlyExistenceCheckerRepository existenceCheckerRepository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _existenceCheckerRepository = existenceCheckerRepository;
        }

        public async Task<ResponseCreateContract> Execute(RequestContract request)
        {
            await Validate(request);

            var contract = new Contract
            {
                BeginDate = request.BeginDate,
                EndDate = request.EndDate,
                CreatedAt = DateTime.UtcNow,
                HouseId = request.HouseId,
                TenantId = request.TenantId,
                Url = request.Url
            };

            await _repository.Add(contract);
            await _unitOfWork.Commit();

            return new ResponseCreateContract
            {
                Id = contract.Id,
                BeginDate = contract.BeginDate,
                EndDate = contract.EndDate,
                HouseId = contract.HouseId,
                TenantId = contract.TenantId,
                CreatedAt = contract.CreatedAt
            };
        }

        private async Task Validate(RequestContract request)
        {
            var result = new ContractValidator().Validate(request);

            var houseExist = await _existenceCheckerRepository.HouseExist(request.HouseId);
            if (!houseExist)
                result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.HOUSE_NOT_FOUND));

            var tenatExist = await _existenceCheckerRepository.TenantExist(request.TenantId);
            if (!tenatExist)
                result.Errors.Add(new ValidationFailure(string.Empty, ResourceErrorMessages.TENANT_NOT_FOUND));

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}

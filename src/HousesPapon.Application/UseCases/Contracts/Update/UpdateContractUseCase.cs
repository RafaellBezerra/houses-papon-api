using FluentValidation.Results;
using HousesPapon.Communication.Requests.Contracts;
using HousesPapon.Domain.Repositories.CommomUtilities;
using HousesPapon.Domain.Repositories.Contract;
using HousesPapon.Exception.Resources;
using HousesPapon.Exception;

namespace HousesPapon.Application.UseCases.Contracts.Update
{
    public class UpdateContractUseCase : IUpdateContractUseCase
    {
        private readonly IContractUpdateOnlyRepository _repository;
        private readonly IReadOnlyExistenceCheckerRepository _existenceCheckerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateContractUseCase(IContractUpdateOnlyRepository repository, IUnitOfWork unitOfWork, IReadOnlyExistenceCheckerRepository existenceCheckerRepository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _existenceCheckerRepository = existenceCheckerRepository;
        }

        public async Task Execute(long Id, RequestContract request)
        {
            await Validate(request);

            var contract = await _repository.GetById(Id) ?? throw new NotFoundException(ResourceErrorMessages.CONTRACT_NOT_FOUND);

            contract.Url = request.Url;
            contract.BeginDate = request.BeginDate;
            contract.EndDate = request.EndDate;
            contract.TenantId = request.TenantId;
            contract.HouseId = request.HouseId;

            _repository.Update(contract);
            await _unitOfWork.Commit();
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

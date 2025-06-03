using HousesPapon.Communication.Responses.Contracts;
using HousesPapon.Domain.Repositories.Contract;
using HousesPapon.Exception;
using HousesPapon.Exception.Resources;

namespace HousesPapon.Application.UseCases.Contracts.GetById
{
    public class GetContractByIdUseCase : IGetContractByIdUseCase
    {
        private readonly IContractReadOnlyRepository _repository;
        public GetContractByIdUseCase(IContractReadOnlyRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseGetContractById> Execute(long Id)
        {
            var contract = await _repository.GetById(Id) ?? throw new NotFoundException(ResourceErrorMessages.CONTRACT_NOT_FOUND);

            return new ResponseGetContractById
            {
                Id = contract.Id,
                BeginDate = contract.BeginDate,
                CreatedAt = contract.CreatedAt,
                EndDate = contract.EndDate,
                HouseId = contract.HouseId,
                TenantId = contract.TenantId,
                Url = contract.Url
            };
        }
    }
}

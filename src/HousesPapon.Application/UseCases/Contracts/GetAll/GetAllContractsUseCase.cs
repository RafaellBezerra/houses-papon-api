using HousesPapon.Communication.Responses.Contracts;
using HousesPapon.Domain.Repositories.Contract;

namespace HousesPapon.Application.UseCases.Contracts.GetAll
{
    public class GetAllContractsUseCase : IGetAllContractsUseCase
    {
        private readonly IContractReadOnlyRepository _repository;
        public GetAllContractsUseCase(IContractReadOnlyRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseGetAllContracts> Execute()
        {
            var contracts = await _repository.GetAll();

            return new ResponseGetAllContracts
            {
                Contracts = contracts.Select(c => new ResponseForGetAllContracts
                {
                    Id = c.Id,
                    BeginDate = c.BeginDate,
                    CreatedAt = c.CreatedAt,
                    EndDate = c.EndDate,
                    HouseId = c.HouseId,
                    TenantId = c.TenantId,
                    Url = c.Url
                }).ToList()
            };
        }
    }
}

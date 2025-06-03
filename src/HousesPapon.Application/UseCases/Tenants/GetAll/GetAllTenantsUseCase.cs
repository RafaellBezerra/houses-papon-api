using HousesPapon.Communication.Responses.Tenants;
using HousesPapon.Domain.Repositories.Tenant;

namespace HousesPapon.Application.UseCases.Tenants.GetAll
{
    public class GetAllTenantsUseCase : IGetAllTenantsUseCase
    {
        private readonly ITenantReadOnlyRepository _repository;
        public GetAllTenantsUseCase(ITenantReadOnlyRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseGetAllTenants> Execute()
        {
            var tenants = await _repository.GetAll();

            return new ResponseGetAllTenants
            {
                Tenants = tenants.Select(x => new ResponseForGetAllTenants
                {
                    Id = x.Id,
                    CreatedAt = x.CreatedAt,
                    EntranceDate = x.EntranceDate,
                    IsInDebit = x.IsInDebit,
                    Name = x.Name,
                    PayDay = x.PayDay,
                    HouseId = x.HouseId,
                }).ToList()
            };
        }
    }
}

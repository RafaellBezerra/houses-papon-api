using HousesPapon.Communication.Responses.Tenants;
using HousesPapon.Domain.Repositories.Tenant;
using HousesPapon.Exception;
using HousesPapon.Exception.Resources;

namespace HousesPapon.Application.UseCases.Tenants.GetById
{
    public class GetTenantByIdUseCase : IGetTenantByIdUseCase
    {
        private readonly ITenantReadOnlyRepository _repository;
        public GetTenantByIdUseCase(ITenantReadOnlyRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseGetTenantById> Execute(long Id)
        {
            var tenant = await _repository.GetById(Id) ?? throw new NotFoundException(ResourceErrorMessages.TENANT_NOT_FOUND);

            return new ResponseGetTenantById
            {
                Id = tenant.Id,
                CreatedAt = tenant.CreatedAt,
                EntranceDate = tenant.EntranceDate,
                IsInDebit = tenant.IsInDebit,
                Name = tenant.Name,
                PayDay = tenant.PayDay,
                HouseId = tenant.HouseId
            };
        }
    }
}

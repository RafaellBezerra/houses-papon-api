using HousesPapon.Communication.Responses.Tenants;

namespace HousesPapon.Application.UseCases.Tenants.GetById_TenantContracts_
{
    public interface IGetTenantContractsUseCase
    {
        Task<ResponseGetTenantContracts> Execute(long Id);
    }
}

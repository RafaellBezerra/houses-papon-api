using HousesPapon.Communication.Requests.Tenants;

namespace HousesPapon.Application.UseCases.Tenants.Update
{
    public interface IUpdateTenantUseCase
    {
        Task Execute(RequestTenant request, long Id);
    }
}

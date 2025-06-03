using HousesPapon.Communication.Requests.Tenants;
using HousesPapon.Communication.Responses.Tenants;

namespace HousesPapon.Application.UseCases.Tenants.Create
{
    public interface ICreateTenantUseCase
    {
        Task<ResponseCreateTenant> Execute(RequestTenant request);
    }
}

using HousesPapon.Communication.Responses.Tenants;

namespace HousesPapon.Application.UseCases.Tenants.GetById
{
    public interface IGetTenantByIdUseCase
    {
        Task<ResponseGetTenantById> Execute(long Id);
    }
}

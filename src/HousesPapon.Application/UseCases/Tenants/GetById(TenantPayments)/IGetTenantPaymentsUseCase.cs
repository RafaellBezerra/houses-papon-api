using HousesPapon.Communication.Responses.Tenants;

namespace HousesPapon.Application.UseCases.Tenants.GetById_TenantPayments_
{
    public interface IGetTenantPaymentsUseCase
    {
        Task<List<ResponseGetTenantPayments>> Execute(long Id);
    }
}

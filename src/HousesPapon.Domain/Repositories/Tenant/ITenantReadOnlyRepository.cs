namespace HousesPapon.Domain.Repositories.Tenant
{
    public interface ITenantReadOnlyRepository
    {
        Task<List<Entities.Tenant>> GetAll();
        Task<Entities.Tenant?> GetById(long id);
        Task<List<Entities.Payment>> GetTenantPaymentsById(long id);
        Task<List<Entities.Contract>> GetTenantContractsById(long id);
    }
}

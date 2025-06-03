namespace HousesPapon.Domain.Repositories.Tenant
{
    public interface ITenantWriteOnlyRepository
    {
        Task Add(Entities.Tenant tenant);
        Task<bool> Delete(long id);
    }
}

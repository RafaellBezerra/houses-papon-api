namespace HousesPapon.Domain.Repositories.Tenant
{
    public interface ITenantUpdateOnlyRepository
    {
        Task<Entities.Tenant?> GetById(long id);
        void Update(Entities.Tenant tenant);
    }
}

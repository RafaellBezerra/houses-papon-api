using HousesPapon.Domain.Entities;
using HousesPapon.Domain.Repositories.Tenant;
using Microsoft.EntityFrameworkCore;

namespace HousesPapon.Infrastructure.DataAccess.Repositories
{
    internal class TenantsRepository : ITenantReadOnlyRepository, ITenantUpdateOnlyRepository, ITenantWriteOnlyRepository
    {
        private readonly HousesPaponDbContext _dbContext;
        public TenantsRepository(HousesPaponDbContext dbContext) => _dbContext = dbContext;

        public async Task Add(Tenant tenant)
        {
            await _dbContext.Tenants.AddAsync(tenant);
        }

        public async Task<bool> Delete(long id)
        {
            var tenant = await _dbContext.Tenants.FirstOrDefaultAsync(t => t.Id == id);
            if (tenant is null) return false;

            _dbContext.Tenants.Remove(tenant);
            return true;
        }

        public async Task<List<Tenant>> GetAll()
        {
            return await _dbContext.Tenants.AsNoTracking().ToListAsync();
        }

        async Task<Tenant?> ITenantReadOnlyRepository.GetById(long id)
        {
            return await _dbContext.Tenants.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<Contract>> GetTenantContractsById(long id)
        {
            return await _dbContext.Contracts.Where(c => c.TenantId == id).OrderByDescending(x => x.CreatedAt).ToListAsync();
        }

        public async Task<List<Payment>> GetTenantPaymentsById(long id)
        {
            return await _dbContext.Payments.Where(p => p.TenantId == id).OrderByDescending(x => x.CreatedAt).ToListAsync();
        } 

        public void Update(Tenant tenant)
        {
            _dbContext.Tenants.Update(tenant);
        }

        async Task<Tenant?> ITenantUpdateOnlyRepository.GetById(long id)
        {
            return await _dbContext.Tenants.FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}

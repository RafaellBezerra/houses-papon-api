using HousesPapon.Domain.Repositories.CommomUtilities;
using Microsoft.EntityFrameworkCore;

namespace HousesPapon.Infrastructure.DataAccess.Repositories.CommonUtilities
{
    internal class ExistenceCheckerRepository : IReadOnlyExistenceCheckerRepository
    {
        private readonly HousesPaponDbContext _dbContext;
        public ExistenceCheckerRepository(HousesPaponDbContext dbContext) => _dbContext = dbContext;

        public async Task<bool> HouseExist(long id)
        {
            return await _dbContext.Houses.AnyAsync(h => h.Id == id);
        }

        public async Task<bool> TenantExist(long id)
        {
            return await _dbContext.Tenants.AnyAsync(h => h.Id == id);
        }
    }
}

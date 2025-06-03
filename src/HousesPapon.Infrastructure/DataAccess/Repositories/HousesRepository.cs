using HousesPapon.Domain.Entities;
using HousesPapon.Domain.Repositories.House;
using Microsoft.EntityFrameworkCore;

namespace HousesPapon.Infrastructure.DataAccess.Repositories
{
    internal class HousesRepository : IHouseReadOnlyRepository
    {
        private readonly HousesPaponDbContext _dbContext;
        public HousesRepository(HousesPaponDbContext dbContext) => _dbContext = dbContext;

        public async Task<List<House>> GetAll()
        {
            return await _dbContext.Houses.AsNoTracking().Include(h => h.Tenant).ToListAsync();
        }

        public async Task<House?> GetById(long id)
        {
            return await _dbContext.Houses.AsNoTracking().FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<List<House>> GetAvailableHouses()
        {
            return await _dbContext.Houses.AsNoTracking().Where(h => h.Tenant == null).ToListAsync();
        }

        public async Task<List<Contract>> GetHouseContractsById(long id)
        {
            return await _dbContext.Contracts.AsNoTracking().Where(x =>x.HouseId == id).OrderByDescending(x => x.CreatedAt).ToListAsync();
        }

        public async Task<List<Payment>> GetHousePaymentsById(long id)
        {
            return await _dbContext.Payments.AsNoTracking().Where(x => x.HouseId == id).OrderByDescending(x => x.CreatedAt).ToListAsync();
        }
    }
}

using HousesPapon.Domain.Repositories.CommomUtilities;

namespace HousesPapon.Infrastructure.DataAccess.Repositories.CommonUtilities
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly HousesPaponDbContext _dbContext;
        public UnitOfWork(HousesPaponDbContext dbContext) => _dbContext = dbContext;

        public async Task Commit() => await _dbContext.SaveChangesAsync();
    }
}

using HousesPapon.Domain.Entities;
using HousesPapon.Domain.Repositories.Contract;
using Microsoft.EntityFrameworkCore;

namespace HousesPapon.Infrastructure.DataAccess.Repositories
{
    internal class ContractsRepository : IContractReadOnlyRepository, IContractUpdateOnlyRepository, IContractWriteOnlyRepository
    {
        private readonly HousesPaponDbContext _dbContext;
        public ContractsRepository(HousesPaponDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Contract contract)
        {
            await _dbContext.Contracts.AddAsync(contract);
        }

        public async Task<bool> Delete(long id)
        {
            var contract = await _dbContext.Contracts.FirstOrDefaultAsync(c => c.Id == id);
            if (contract is null) return false;

            _dbContext.Contracts.Remove(contract);
            return true;
        }

        public async Task<List<Contract>> GetAll()
        {
            return await _dbContext.Contracts.AsNoTracking().ToListAsync();
        }

        async Task<Contract?> IContractUpdateOnlyRepository.GetById(long Id)
        {
            return await _dbContext.Contracts.FirstOrDefaultAsync(c => c.Id == Id);
        }

        public void Update(Contract contract)
        {
            _dbContext.Contracts.Update(contract);
        }

        async Task<Contract?> IContractReadOnlyRepository.GetById(long id)
        {
            return await _dbContext.Contracts.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}

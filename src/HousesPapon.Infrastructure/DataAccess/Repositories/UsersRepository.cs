using HousesPapon.Domain.Entities;
using HousesPapon.Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace HousesPapon.Infrastructure.DataAccess.Repositories
{
    internal class UsersRepository : IUserWriteOnlyRepository, IUserReadOnlyRepository
    {
        private readonly HousesPaponDbContext _dbContext;
        public UsersRepository(HousesPaponDbContext dbContext) => _dbContext = dbContext;

        public async Task Add(User user)
        {
            await _dbContext.Users.AddAsync(user);
        }

        public async Task<bool> ExistUserWithThisEmail(string email)
        {
            return await _dbContext.Users.AnyAsync(u => u.Email.Equals(email));
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}

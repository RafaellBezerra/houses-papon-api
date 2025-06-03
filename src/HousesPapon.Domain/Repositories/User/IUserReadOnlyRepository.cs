using HousesPapon.Domain.Entities;

namespace HousesPapon.Domain.Repositories.User
{
    public interface IUserReadOnlyRepository
    {
        Task<bool> ExistUserWithThisEmail(string email);
        Task<Entities.User?> GetUserByEmail(string email);
    }
}

using BC = BCrypt.Net.BCrypt;
using HousesPapon.Domain.Security.Cryptografy;

namespace HousesPapon.Infrastructure.Security.Cryptografy
{
    internal class PasswordEncripter : IPasswordEncripter
    {
        public string Encrypt(string password)
        {
            var passwordHash = BC.HashPassword(password);

            return passwordHash;
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            return BC.Verify(password, passwordHash);
        }
    }
}

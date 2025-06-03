namespace HousesPapon.Domain.Security.Cryptografy
{
    public interface IPasswordEncripter
    {
        string Encrypt(string password);
        bool VerifyPassword(string password, string passworHash);
    }
}

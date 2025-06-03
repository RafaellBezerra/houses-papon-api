namespace HousesPapon.Domain.Repositories.CommomUtilities
{
    public interface IReadOnlyExistenceCheckerRepository
    {
        Task<bool> HouseExist(long id);
        Task<bool> TenantExist(long id);
    }
}

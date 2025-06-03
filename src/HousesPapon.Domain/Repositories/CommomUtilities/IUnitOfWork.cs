namespace HousesPapon.Domain.Repositories.CommomUtilities
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}

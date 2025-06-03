namespace HousesPapon.Domain.Repositories.Image
{
    public interface IImageWriteOnlyRepository
    {
        Task Add(Entities.Image image);
        Task<bool> Delete(long id);
    }
}

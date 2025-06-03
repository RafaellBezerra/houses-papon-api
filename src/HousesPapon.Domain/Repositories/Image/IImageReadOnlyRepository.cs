namespace HousesPapon.Domain.Repositories.Image
{
    public interface IImageReadOnlyRepository
    {
        Task<List<Entities.Image>> GetAll();
        Task<Entities.Image?> GetImageById(long id);
    }
}

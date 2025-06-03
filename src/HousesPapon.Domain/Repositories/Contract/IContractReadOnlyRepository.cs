namespace HousesPapon.Domain.Repositories.Contract
{
    public interface IContractReadOnlyRepository
    {
        Task<List<Entities.Contract>> GetAll();
        Task<Entities.Contract?> GetById(long id);
    }
}

namespace HousesPapon.Domain.Repositories.Contract
{
    public interface IContractUpdateOnlyRepository
    {
        void Update(Entities.Contract contract);
        Task<Entities.Contract?> GetById(long id);
    }
}

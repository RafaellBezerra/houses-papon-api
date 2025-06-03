namespace HousesPapon.Domain.Repositories.Contract
{
    public interface IContractWriteOnlyRepository
    {
        Task Add(Entities.Contract contract);
        Task<bool> Delete(long id);
    }
}

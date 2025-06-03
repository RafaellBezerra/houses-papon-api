namespace HousesPapon.Domain.Repositories.House
{
    public interface IHouseReadOnlyRepository
    {
        Task<List<Entities.House>> GetAll();
        Task<Entities.House?> GetById(long id);
        Task<List<Entities.Payment>> GetHousePaymentsById(long id);
        Task<List<Entities.Contract>> GetHouseContractsById(long id);
        Task<List<Entities.House>> GetAvailableHouses();
    }
}

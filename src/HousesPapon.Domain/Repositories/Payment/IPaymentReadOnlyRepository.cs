namespace HousesPapon.Domain.Repositories.Payment
{
    public interface IPaymentReadOnlyRepository
    {
        Task<List<Entities.Payment>> GetAll();
        Task<Entities.Payment?> GetById(long id);
    }
}

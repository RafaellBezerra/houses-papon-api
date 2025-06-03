namespace HousesPapon.Domain.Repositories.Payment
{
    public interface IPaymentUpdateOnlyRepository
    {
        void Update(Entities.Payment payment);
        Task<Entities.Payment?> GetById(long id);
    }
}

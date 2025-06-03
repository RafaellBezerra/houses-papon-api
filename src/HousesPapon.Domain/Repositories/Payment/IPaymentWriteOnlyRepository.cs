namespace HousesPapon.Domain.Repositories.Payment
{
    public interface IPaymentWriteOnlyRepository
    {
        Task Add(Entities.Payment payment);
        Task<bool> Delete(long id);
    }
}

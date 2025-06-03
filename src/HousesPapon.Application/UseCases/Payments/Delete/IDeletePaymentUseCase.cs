namespace HousesPapon.Application.UseCases.Payments.Delete
{
    public interface IDeletePaymentUseCase
    {
        Task Execute(long Id);
    }
}

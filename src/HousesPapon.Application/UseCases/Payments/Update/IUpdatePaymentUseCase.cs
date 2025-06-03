using HousesPapon.Communication.Requests.Payments;

namespace HousesPapon.Application.UseCases.Payments.Update
{
    public interface IUpdatePaymentUseCase
    {
        Task Execute(RequestPayment request, long Id);
    }
}

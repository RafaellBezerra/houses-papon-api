using HousesPapon.Communication.Requests.Payments;
using HousesPapon.Communication.Responses.Payments;

namespace HousesPapon.Application.UseCases.Payments.Create
{
    public interface ICreatePaymentUseCase
    {
        Task<ResponseCreatePayment> Execute(RequestPayment request);
    }
}

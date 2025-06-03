using HousesPapon.Communication.Responses.Payments;

namespace HousesPapon.Application.UseCases.Payments.GetById
{
    public interface IGetPaymentByIdUseCase
    {
        Task<ResponseGetPaymentById> Execute(long Id);
    }
}

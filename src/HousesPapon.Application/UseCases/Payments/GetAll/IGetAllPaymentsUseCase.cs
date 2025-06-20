using HousesPapon.Communication.Responses.Payments;

namespace HousesPapon.Application.UseCases.Payments.GetAll
{
    public interface IGetAllPaymentsUseCase
    {
        Task<List<ResponseGetAllPayments>> Execute();
    }
}

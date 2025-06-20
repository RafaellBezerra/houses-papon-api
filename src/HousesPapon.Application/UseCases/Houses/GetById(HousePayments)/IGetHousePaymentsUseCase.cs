using HousesPapon.Communication.Responses.Houses;

namespace HousesPapon.Application.UseCases.Houses.GetById_HousePayments_
{
    public interface IGetHousePaymentsUseCase
    {
        Task<List<ResponseGetHousePayments>> Execute(long Id);
    }
}

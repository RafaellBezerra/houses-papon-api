using HousesPapon.Communication.Responses.Houses;

namespace HousesPapon.Application.UseCases.Houses.GetById_HousePayments_
{
    public interface IGetHousePaymentsUseCase
    {
        Task<ResponseGetHousePayments> Execute(long Id);
    }
}

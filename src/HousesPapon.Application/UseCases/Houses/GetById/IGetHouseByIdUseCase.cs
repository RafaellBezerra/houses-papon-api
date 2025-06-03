using HousesPapon.Communication.Responses.Houses;

namespace HousesPapon.Application.UseCases.Houses.GetById
{
    public interface IGetHouseByIdUseCase
    {
        Task<ResponseGetHouseById> Execute(long Id);
    }
}

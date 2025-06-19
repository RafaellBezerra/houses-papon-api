using HousesPapon.Communication.Responses.Houses;

namespace HousesPapon.Application.UseCases.Houses.GetAll
{
    public interface IGetAllHousesUseCase
    {
        Task<List<ResponseGetAllHouses>> Execute();
    }
}

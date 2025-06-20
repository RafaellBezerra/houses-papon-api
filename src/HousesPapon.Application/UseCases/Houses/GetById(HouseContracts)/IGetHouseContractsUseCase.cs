using HousesPapon.Communication.Responses.Houses;

namespace HousesPapon.Application.UseCases.Houses.GetById_HouseContracts_
{
    public interface IGetHouseContractsUseCase
    {
        Task<List<ResponseGetHouseContracts>> Execute(long id);
    }
}

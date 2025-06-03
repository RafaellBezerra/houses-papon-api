using HousesPapon.Communication.Responses.Contracts;

namespace HousesPapon.Application.UseCases.Contracts.GetAll
{
    public interface IGetAllContractsUseCase
    {
        Task<ResponseGetAllContracts> Execute();
    }
}

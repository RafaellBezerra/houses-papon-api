using HousesPapon.Communication.Responses.Contracts;

namespace HousesPapon.Application.UseCases.Contracts.GetAll
{
    public interface IGetAllContractsUseCase
    {
        Task<List<ResponseGetAllContracts>> Execute();
    }
}

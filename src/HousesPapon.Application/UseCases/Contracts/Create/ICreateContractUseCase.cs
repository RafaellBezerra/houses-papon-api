using HousesPapon.Communication.Requests.Contracts;
using HousesPapon.Communication.Responses.Contracts;

namespace HousesPapon.Application.UseCases.Contracts.Create
{
    public interface ICreateContractUseCase
    {
        Task<ResponseCreateContract> Execute(RequestContract request);
    }
}

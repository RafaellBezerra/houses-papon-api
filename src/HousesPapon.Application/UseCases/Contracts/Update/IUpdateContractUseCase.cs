using HousesPapon.Communication.Requests.Contracts;

namespace HousesPapon.Application.UseCases.Contracts.Update
{
    public interface IUpdateContractUseCase
    {
        Task Execute(long Id, RequestContract request);
    }
}

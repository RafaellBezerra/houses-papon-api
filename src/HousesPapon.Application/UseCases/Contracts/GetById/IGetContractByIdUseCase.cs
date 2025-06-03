using HousesPapon.Communication.Responses.Contracts;

namespace HousesPapon.Application.UseCases.Contracts.GetById
{
    public interface IGetContractByIdUseCase
    {
        Task<ResponseGetContractById> Execute(long Id);
    }
}

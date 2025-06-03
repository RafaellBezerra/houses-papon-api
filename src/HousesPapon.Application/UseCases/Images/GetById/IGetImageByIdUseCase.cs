using HousesPapon.Communication.Responses.Images;

namespace HousesPapon.Application.UseCases.Images.GetById
{
    public interface IGetImageByIdUseCase
    {
        Task<ResponseGetImageById> Execute(long Id);
    }
}

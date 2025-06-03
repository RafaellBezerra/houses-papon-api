using HousesPapon.Communication.Requests.Images;
using HousesPapon.Communication.Responses.Images;

namespace HousesPapon.Application.UseCases.Images.Add
{
    public interface IAddImageUseCase
    {
        Task<ResponseAddImage> Execute(RequestAddImage request);
    }
}

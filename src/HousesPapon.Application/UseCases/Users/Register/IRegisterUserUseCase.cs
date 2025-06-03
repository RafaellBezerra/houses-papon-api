using HousesPapon.Communication.Requests.User;
using HousesPapon.Communication.Responses.User;

namespace HousesPapon.Application.UseCases.Users.Register
{
    public interface IRegisterUserUseCase
    {
        Task<ResponseRegisterUser> Execute(RequestRegisterUser request);
    }
}

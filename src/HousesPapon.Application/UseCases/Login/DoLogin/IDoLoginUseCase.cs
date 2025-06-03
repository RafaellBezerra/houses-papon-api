using HousesPapon.Communication.Requests.Login;
using HousesPapon.Communication.Responses.User;

namespace HousesPapon.Application.UseCases.Login.DoLogin
{
    public interface IDoLoginUseCase
    {
        Task<ResponseRegisterUser> Execute(RequestLogin request);
    }
}

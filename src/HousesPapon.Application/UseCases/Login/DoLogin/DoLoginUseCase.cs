using HousesPapon.Communication.Requests.Login;
using HousesPapon.Communication.Responses.User;
using HousesPapon.Domain.Repositories.User;
using HousesPapon.Domain.Security.Cookie;
using HousesPapon.Domain.Security.Cryptografy;
using HousesPapon.Exception;

namespace HousesPapon.Application.UseCases.Login.DoLogin
{
    public class DoLoginUseCase : IDoLoginUseCase
    {
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IPasswordEncripter _passwordEncripter;
        private readonly ICookieGenerator _cookieGenerator;
        public DoLoginUseCase(IUserReadOnlyRepository userReadOnlyRepository, IPasswordEncripter passwordEncripter, ICookieGenerator cookieGenerator)
        {
            _userReadOnlyRepository = userReadOnlyRepository;
            _passwordEncripter = passwordEncripter;
            _cookieGenerator = cookieGenerator;
        }
        public async Task<ResponseRegisterUser> Execute(RequestLogin request)
        {
            var user = await _userReadOnlyRepository.GetUserByEmail(request.Email) ?? throw new InvalidLoginException();

            var passwordMatch = _passwordEncripter.VerifyPassword(request.Password, user.Password);

            if (!passwordMatch)
                throw new InvalidLoginException();

            await _cookieGenerator.Generate(user);

            return new ResponseRegisterUser
            {
                Name = user.Name
            };
        }
    }
}

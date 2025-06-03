
using HousesPapon.Domain.Security.Cookie;

namespace HousesPapon.Application.UseCases.Login.DoLogout
{
    public class DoLogoutUseCase : IDoLogoutUseCase
    {
        private readonly ICookieGenerator _cookieGenerator;
        public DoLogoutUseCase(ICookieGenerator cookieGenerator)
        {
            _cookieGenerator = cookieGenerator;
        }
        public async Task Execute()
        {
            await _cookieGenerator.Logout();
        }
    }
}

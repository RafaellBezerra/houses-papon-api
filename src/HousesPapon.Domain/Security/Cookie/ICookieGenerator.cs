using HousesPapon.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace HousesPapon.Domain.Security.Cookie
{
    public interface ICookieGenerator
    {
        Task Generate(User user);
        Task Logout();
    }
}

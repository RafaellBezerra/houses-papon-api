using HousesPapon.Application.UseCases.Login.DoLogin;
using HousesPapon.Application.UseCases.Login.DoLogout;
using HousesPapon.Communication.Requests.Login;
using HousesPapon.Communication.Responses;
using HousesPapon.Communication.Responses.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HousesPapon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterUser), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromServices] IDoLoginUseCase useCase, [FromBody] RequestLogin request)
        {
            var response = await useCase.Execute(request);
            return Ok(response);
        }

        [HttpPost("Logout")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Logout([FromServices] IDoLogoutUseCase useCase)
        {
            await useCase.Execute();
            return NoContent();
        }
    }
}

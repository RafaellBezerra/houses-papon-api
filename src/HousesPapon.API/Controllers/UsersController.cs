using HousesPapon.Application.UseCases.Users.Register;
using HousesPapon.Communication.Requests.User;
using HousesPapon.Communication.Responses;
using HousesPapon.Communication.Responses.User;
using Microsoft.AspNetCore.Mvc;

namespace HousesPapon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseRegisterUser), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromServices] IRegisterUserUseCase useCase, [FromBody] RequestRegisterUser request)
        {
            var response = await useCase.Execute(request);
            return Created(string.Empty, response);
        }
    }
}

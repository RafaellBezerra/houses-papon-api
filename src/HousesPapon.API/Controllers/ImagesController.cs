using HousesPapon.Application.UseCases.Images.Add;
using HousesPapon.Application.UseCases.Images.Delete;
using HousesPapon.Application.UseCases.Images.GetAll;
using HousesPapon.Application.UseCases.Images.GetById;
using HousesPapon.Communication.Requests.Images;
using HousesPapon.Communication.Responses;
using HousesPapon.Communication.Responses.Images;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HousesPapon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ImagesController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseAddImage), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] RequestAddImage request, [FromServices] IAddImageUseCase useCase)
        {
            var response = await useCase.Execute(request);
            return Created(string.Empty, response);
        }

        [HttpDelete]
        [Route("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] long Id, [FromServices] IDeleteImageUseCase useCase)
        {
            await useCase.Execute(Id);
            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseForGetAllImages), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll([FromServices] IGetAllImagesUseCase useCase)
        {
            var response = await useCase.Execute();
            if (response.Images.Count != 0) return Ok(response);

            return NoContent();
        }

        [HttpGet]
        [Route("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] long Id, [FromServices] IGetImageByIdUseCase useCase)
        {
            var response = await useCase.Execute(Id);
            return Ok(response);
        }
    }
}

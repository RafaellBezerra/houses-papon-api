using HousesPapon.Application.UseCases.Contracts.Create;
using HousesPapon.Application.UseCases.Contracts.Delete;
using HousesPapon.Application.UseCases.Contracts.GetAll;
using HousesPapon.Application.UseCases.Contracts.GetById;
using HousesPapon.Application.UseCases.Contracts.Update;
using HousesPapon.Communication.Requests.Contracts;
using HousesPapon.Communication.Responses;
using HousesPapon.Communication.Responses.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HousesPapon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContractsController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseCreateContract), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] RequestContract request, [FromServices] ICreateContractUseCase useCase)
        {
            var response = await useCase.Execute(request);
            return Created(string.Empty, response);
        }

        [HttpDelete]
        [Route("{Id}")]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromServices] IDeleteContractUseCase useCase, [FromRoute] long Id)
        {
            await useCase.Execute(Id);
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ResponseGetAllContracts>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromServices] IGetAllContractsUseCase useCase)
        {
            var response = await useCase.Execute();
            return Ok(response);
        }

        [HttpGet]
        [Route("{Id}")]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromServices] IGetContractByIdUseCase useCase, [FromRoute] long Id)
        {
            var response = await useCase.Execute(Id);
            return Ok(response);
        }

        [HttpPut]
        [Route("{Id}")]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromServices] IUpdateContractUseCase useCase, [FromRoute] long Id, [FromBody] RequestContract request)
        {
            await useCase.Execute(Id, request);
            return Ok();
        }
    }
}

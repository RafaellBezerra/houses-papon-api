using HousesPapon.Application.UseCases.Houses.GetAll;
using HousesPapon.Application.UseCases.Houses.GetAvailableHouses;
using HousesPapon.Application.UseCases.Houses.GetById;
using HousesPapon.Application.UseCases.Houses.GetById_HouseContracts_;
using HousesPapon.Application.UseCases.Houses.GetById_HousePayments_;
using HousesPapon.Communication.Responses;
using HousesPapon.Communication.Responses.Houses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HousesPapon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HousesController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseForGetAllHouses), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllHouses([FromServices] IGetAllHousesUseCase useCase)
        {
            var response = await useCase.Execute();
            if (response.Houses.Count != 0) return Ok(response);

            return NoContent();
        }

        [HttpGet]
        [Route("{Id}")]
        [ProducesResponseType(typeof(ResponseGetHouseById), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromServices] IGetHouseByIdUseCase useCase, [FromRoute] long Id)
        {
            var response = await useCase.Execute(Id);
            return Ok(response);
        }

        [HttpGet]
        [Route("payments/{Id}")]
        [ProducesResponseType(typeof(ResponseGetHouseById), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetHousePaymentsById([FromRoute] long Id, [FromServices] IGetHousePaymentsUseCase useCase)
        {
            var response = await useCase.Execute(Id);
            if (response.Payments.Count != 0) return Ok(response);

            return NoContent();
        }

        [HttpGet]
        [Route("contracts/{Id}")]
        [ProducesResponseType(typeof(ResponseGetHouseById), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetHouseContractById([FromServices] IGetHouseContractsUseCase useCase, [FromRoute] long Id)
        {
            var response = await useCase.Execute(Id);
            if (response.Contracts.Count != 0) return Ok(response);

            return NoContent();
        }

        [HttpGet]
        [Route("availableHouses")]
        [ProducesResponseType(typeof(ResponseForGetAvailableHouses), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAvailableHouses([FromServices] IGetAvailableHousesUseCase useCase)
        {
            var response = await useCase.Execute();
            if (response.Houses.Count != 0) return Ok(response);

            return NoContent();
        }
    }
}

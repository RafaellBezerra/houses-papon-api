using HousesPapon.Application.UseCases.Payments.Create;
using HousesPapon.Application.UseCases.Payments.Delete;
using HousesPapon.Application.UseCases.Payments.GetAll;
using HousesPapon.Application.UseCases.Payments.GetById;
using HousesPapon.Application.UseCases.Payments.Update;
using HousesPapon.Communication.Requests.Payments;
using HousesPapon.Communication.Responses;
using HousesPapon.Communication.Responses.Payments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HousesPapon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentsController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseCreatePayment), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] RequestPayment request, [FromServices] ICreatePaymentUseCase useCase)
        {
            var response = await useCase.Execute(request);
            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseForGetAllPayments), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll([FromServices] IGetAllPaymentsUseCase useCase)
        {
            var response = await useCase.Execute();
            if (response.Payments.Count != 0) return Ok(response);

            return NoContent();
        }

        [HttpGet]
        [Route("{Id}")]
        [ProducesResponseType(typeof(ResponseGetPaymentById), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] long Id, [FromServices] IGetPaymentByIdUseCase useCase)
        {
            var response = await useCase.Execute(Id);
            return Ok(response);
        }
        
        [HttpDelete]
        [Route("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] long Id, [FromServices] IDeletePaymentUseCase useCase)
        {
            await useCase.Execute(Id);
            return NoContent();
        }
        
        [HttpPut]
        [Route("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromRoute] long Id, [FromServices] IUpdatePaymentUseCase useCase, [FromBody] RequestPayment request)
        {
            await useCase.Execute(request, Id);
            return NoContent();
        }
    }
}

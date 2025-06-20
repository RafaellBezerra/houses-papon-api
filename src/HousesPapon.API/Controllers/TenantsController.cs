using HousesPapon.Application.UseCases.Tenants.Create;
using HousesPapon.Application.UseCases.Tenants.Delete;
using HousesPapon.Application.UseCases.Tenants.GetAll;
using HousesPapon.Application.UseCases.Tenants.GetById;
using HousesPapon.Application.UseCases.Tenants.GetById_TenantContracts_;
using HousesPapon.Application.UseCases.Tenants.GetById_TenantPayments_;
using HousesPapon.Application.UseCases.Tenants.Update;
using HousesPapon.Communication.Requests.Tenants;
using HousesPapon.Communication.Responses;
using HousesPapon.Communication.Responses.Tenants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HousesPapon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TenantsController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<ResponseGetAllTenants>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromServices] IGetAllTenantsUseCase useCase)
        {
            var response = await useCase.Execute();
            return Ok(response);
        }

        [HttpGet]
        [Route("{Id}")]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseGetTenantById), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromServices] IGetTenantByIdUseCase useCase, [FromRoute] long Id)
        {
            var response = await useCase.Execute(Id);
            return Ok(response);
        }

        [HttpGet]
        [Route("contracts/{Id}")]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(List<ResponseGetTenantContracts>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTenantContractsById([FromServices] IGetTenantContractsUseCase useCase, [FromRoute] long Id)
        {
            var response = await useCase.Execute(Id);
            return Ok(response);
        }

        [HttpGet]
        [Route("payments/{Id}")]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(List<ResponseGetTenantPayments>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTenantPaymentsById([FromServices] IGetTenantPaymentsUseCase useCase, [FromRoute] long Id)
        {
            var response = await useCase.Execute(Id);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseCreateTenant), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] RequestTenant request, [FromServices] ICreateTenantUseCase useCase)
        {
            var response = await useCase.Execute(request);
            return Created(string.Empty, response);
        }

        [HttpDelete]
        [Route("{Id}")]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromRoute] long Id, [FromServices] IDeleteTenantUseCase useCase)
        {
            await useCase.Execute(Id);
            return Ok();
        }

        [HttpPut]
        [Route("{Id}")]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromRoute] long Id, [FromServices] IUpdateTenantUseCase useCase, [FromBody] RequestTenant request)
        {
            await useCase.Execute(request, Id);
            return Ok();
        }
    }
}

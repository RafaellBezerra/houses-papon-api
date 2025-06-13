using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HousesPapon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Route("health")]
    public class deployController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("ok");
    }
}

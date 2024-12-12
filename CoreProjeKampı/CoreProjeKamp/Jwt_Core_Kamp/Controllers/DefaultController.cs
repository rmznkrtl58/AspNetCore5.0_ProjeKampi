using Jwt_Core_Kamp.Dal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jwt_Core_Kamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult Login()
        {
            return Created("", new BuildToken().CrateToken());
        }
        [Authorize]
        [HttpGet("[action]")]
        public IActionResult page1()
        {
            return Ok("Sayfa 1 için girişiniz başarılıdır.");
        }
    }
}

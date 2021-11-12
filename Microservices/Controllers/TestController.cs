using Microsoft.AspNetCore.Mvc;

namespace Microservices.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : Controller
    {
        [HttpGet()]
        public IActionResult Test()
        {
            return Ok("Test Microservice 1");
        }
    }
}

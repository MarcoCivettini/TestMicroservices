using Microservices2.Messaging.Send;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices2.Controllers
{
    [ApiController]
    [Route("")]
    public class TestController : Controller
    {
        private readonly TestSender _testSender;
        public TestController(TestSender testSender)
        {
            _testSender = testSender;
        }

        [HttpGet("api/test")]
        public IActionResult Test()
        {
            _testSender.SendTestMessage();
            return Ok("Hello world");
        }

    }


}

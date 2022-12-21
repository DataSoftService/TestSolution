using Microsoft.AspNetCore.Mvc;

namespace TestSoluction.Distribution.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            return "Running...";
        }
    }
}

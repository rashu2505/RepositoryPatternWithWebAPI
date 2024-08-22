using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Model;
using Service.Service.Contracts;

namespace RepoDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestDto>>> GetAllTests()
        {
            var tests = await _testService.GetAllTestAsync();
            if (tests == null)
            {
                return NotFound();
            }
            return Ok(tests);
        }

    }
}

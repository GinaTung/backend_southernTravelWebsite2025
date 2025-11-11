using backend_southernTravelWebsite2025.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend_southernTravelWebsite2025.Controllers
{
    // 告訴系統這是一個 API 控制器
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        // GET api/tests/1
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            var dto = await _testService.GetTestDtoAsync(id, ct);
            if (dto is null) return NotFound(new { message = $"Member {id} not found." });

            return Ok(dto);
        }
    }
}

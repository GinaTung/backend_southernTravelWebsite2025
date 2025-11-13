using Microsoft.AspNetCore.Mvc;

namespace backend_southernTravelWebsite2025.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { status = "ok", time = DateTime.UtcNow });
        }
    }
}

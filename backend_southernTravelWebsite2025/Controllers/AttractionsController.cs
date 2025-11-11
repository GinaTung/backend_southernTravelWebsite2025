using backend_southernTravelWebsite2025.DTOs;
using backend_southernTravelWebsite2025.Services;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace backend_southernTravelWebsite2025.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttractionsController : ControllerBase
    {
        private readonly IAttractionsService _service;
        //private readonly IConfiguration _config;  // ✅ 宣告 IConfiguration

        public AttractionsController(IAttractionsService service, IConfiguration config)  // ✅ 注入
        {
            _service = service;
            //_config = config;
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // 👇 要 await，不要把 Task 丟進 Ok(...)
            var dto = await _service.GetAttractions(id);
            if (dto is null) return NotFound();
            return Ok(dto);
        }

    }
}

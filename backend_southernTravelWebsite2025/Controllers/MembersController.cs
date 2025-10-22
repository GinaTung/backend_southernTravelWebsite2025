using backend_southernTravelWebsite2025.DTOs;
using backend_southernTravelWebsite2025.Services;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace backend_southernTravelWebsite2025.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _service;
        private readonly IConfiguration _config;  // ✅ 宣告 IConfiguration

        public MembersController(IMemberService service, IConfiguration config)  // ✅ 注入
        {
            _service = service;
            _config = config;
        }

        [HttpPost]
        public IActionResult Register([FromBody] MemberCreateDto dto)
        {
            var result = _service.Register(dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var member = _service.GetMember(id);
            if (member == null) return NotFound();
            return Ok(member);
        }

        [HttpGet("check-db")]
        public IActionResult CheckDb()
        {
            var connString = _config.GetConnectionString("DefaultConnection");

            try
            {
                using var connection = new NpgsqlConnection(connString);
                connection.Open();
                return Ok("✅ DB 連線成功：" + connection.FullState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"❌ DB 連線失敗：{ex.Message}");
            }
        }
    }
}

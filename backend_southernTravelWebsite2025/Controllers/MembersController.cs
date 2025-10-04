using backend_southernTravelWebsite2025.DTOs;
using backend_southernTravelWebsite2025.Services;
using Microsoft.AspNetCore.Mvc;


namespace backend_southernTravelWebsite2025.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _service;

        public MembersController(IMemberService service)
        {
            _service = service;
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
    }
}

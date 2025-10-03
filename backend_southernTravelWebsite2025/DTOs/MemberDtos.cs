using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend_southernTravelWebsite2025.DTOs
{
    // 建立會員用
    public class MemberCreateDto
    {
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = ""; // 前端傳進來的原始密碼
        public string PhoneNumber { get; set; } = "";
        public DateTime Birthday { get; set; }
    }

    // 回傳給前端用
    public class MemberResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public DateTime Birthday { get; set; }
    }
}

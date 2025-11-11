using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend_southernTravelWebsite2025.DTOs
{
    // 建立會員用
    public class AttractionsCreateDto
    {
        public string Title { get; set; } = "";
        public string Category { get; set; } = "";
        public string Description { get; set; } = ""; 
        public string MainImageUrl { get; set; } = "";
        public string Location { get; set; } = "";
        public string Tag_1 { get; set; } = "";
        public string Tag_2 { get; set; } = "";
    }

    // 回傳給前端用
    public class AttractionsResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Category { get; set; } = "";
        public string Description { get; set; } = "";
        public string MainImageUrl { get; set; } = "";
        public string Location { get; set; } = "";
        public string Tag_1 { get; set; } = "";
        public string Tag_2 { get; set; } = "";
    }
}

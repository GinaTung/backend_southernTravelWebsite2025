using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_southernTravelWebsite2025.Models.Entities
{
    [Table("attractions")] // ✅ 指定對應資料表名稱
    public class Attractions
    {
        [Key]
        [Column("id")] // ✅ 對應資料庫欄位 id
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("category")]
        public string Category { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("main_image_url")]
        public string MainImageUrl { get; set; }

        [Column("location")]
        public string? Location { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        [Column("tag_1")]
        public string Tag_1 { get; set; }

        [Column("tag_2")]
        public string? Tag_2 { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}

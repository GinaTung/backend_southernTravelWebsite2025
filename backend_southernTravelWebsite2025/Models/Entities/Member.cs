using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_southernTravelWebsite2025.Models.Entities
{
    [Table("members")] // ✅ 指定對應資料表名稱
    public class Member
    {
        [Key]
        [Column("id")] // ✅ 對應資料庫欄位 id
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password_hash")]
        public string PasswordHash { get; set; }

        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        [Column("birthday")]
        public DateTime Birthday { get; set; }

        [Column("profile_image")]
        public string? ProfileImage { get; set; }

        [Column("notes")]
        public string? Notes { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}

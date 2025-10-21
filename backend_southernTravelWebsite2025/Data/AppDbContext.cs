using backend_southernTravelWebsite2025.Models;
using backend_southernTravelWebsite2025.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend_southernTravelWebsite2025.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Member> Members { get; set; }
        // 其他資料表可以在這裡加上

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ✅ 指定資料表名稱為小寫 "members"
            modelBuilder.Entity<Member>().ToTable("members");
        }
    }
}

using backend_southernTravelWebsite2025.Data;
using backend_southernTravelWebsite2025.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend_southernTravelWebsite2025.Repositories
{
    public interface IAttractionsRepository
    {
        Task<Attractions?> GetById(int id);
    }

    public class AttractionsRepository : IAttractionsRepository
    {
        //private readonly List<Member> _members = new(); // 先用記憶體模擬，之後再改成 DB
        //連線db
        private readonly AppDbContext _context;

        public AttractionsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Attractions?> GetById(int id)
        {
            // 👇 開頭印出紀錄
            Console.WriteLine($"[Repo] Start GetByIdAsync({id}) at {DateTime.Now:HH:mm:ss.fff}");

            // 真正查詢資料庫
            var result = await _context.Attractions
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            // 👇 結尾印出紀錄
            Console.WriteLine($"[Repo] End GetByIdAsync({id}) at {DateTime.Now:HH:mm:ss.fff}");

            return result;
        }
    }
}

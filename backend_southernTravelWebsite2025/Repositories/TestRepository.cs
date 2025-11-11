using backend_southernTravelWebsite2025.Data;
using backend_southernTravelWebsite2025.Models.Entities;
using backend_southernTravelWebsite2025.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend_southernTravelWebsite2025.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly AppDbContext _db;

        public TestRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Test?> GetByIdAsync(long id, CancellationToken ct = default)
        {
            return await _db.Test
                .AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(ct);
        }

        public async Task<IReadOnlyList<Test>> GetAllAsync()
        {
            return await _db.Test
                .AsNoTracking()
                .OrderBy(m => m.Id)
                .ToListAsync();
        }
    }
}

using backend_southernTravelWebsite2025.Models.Entities;

namespace backend_southernTravelWebsite2025.Repositories.Interfaces
{
    public interface ITestRepository
    {
        Task<Test?> GetByIdAsync(long id, CancellationToken ct = default);
        Task<IReadOnlyList<Test>> GetAllAsync(); // 送你一個清單 API

    }
}

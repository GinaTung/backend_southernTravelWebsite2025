using backend_southernTravelWebsite2025.DTOs;
using backend_southernTravelWebsite2025.Models.Entities;

namespace backend_southernTravelWebsite2025.Services.Interfaces
{
    public interface  ITestService
    {
        Task<TestDtos?> GetTestDtoAsync(long id, CancellationToken ct = default);
        Task<IEnumerable<TestDtos>> GetAllTestsAsync(CancellationToken ct);
    }
}

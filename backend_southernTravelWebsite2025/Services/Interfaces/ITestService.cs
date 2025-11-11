using backend_southernTravelWebsite2025.DTOs;

namespace backend_southernTravelWebsite2025.Services.Interfaces
{
    public interface  ITestService
    {
        Task<TestDtos?> GetTestDtoAsync(int id, CancellationToken ct = default);
    }
}

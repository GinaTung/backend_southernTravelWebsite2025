using backend_southernTravelWebsite2025.DTOs;
using backend_southernTravelWebsite2025.Repositories.Interfaces;

namespace backend_southernTravelWebsite2025.Services
{
    public class TestService : Interfaces.ITestService
    {
        private readonly ITestRepository _testRepo;

        public TestService(ITestRepository testRepo)
        {
            _testRepo = testRepo;
        }

        public async Task<TestDtos?> GetTestDtoAsync(int id, CancellationToken ct = default)
        {
            var test = await _testRepo.GetByIdAsync(id,ct);
            if (test is null) return null;

            return new TestDtos
            {
                Id = test.Id,
                Name = test.Name,
                Email = test.Email
            };
        }
    }
}

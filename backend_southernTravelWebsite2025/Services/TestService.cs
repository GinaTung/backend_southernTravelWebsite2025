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

        // 取得全部
        public async Task<IEnumerable<TestDtos>> GetAllTestsAsync(CancellationToken ct)
        {
            var tests = await _testRepo.GetAllAsync(); // <-- 使用你 repo 的方法

            // Mapping
            return tests.Select(x => new TestDtos
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email
            });
        }

        // 取得單筆
        public async Task<TestDtos?> GetTestDtoAsync(long id, CancellationToken ct = default)
        {
            var test = await _testRepo.GetByIdAsync(id, ct);
            if (test is null)
                return null;

            return new TestDtos
            {
                Id = test.Id,
                Name = test.Name,
                Email = test.Email
            };
        }
    }
}

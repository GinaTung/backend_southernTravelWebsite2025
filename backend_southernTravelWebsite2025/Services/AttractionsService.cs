using backend_southernTravelWebsite2025.DTOs;
using backend_southernTravelWebsite2025.Models.Entities;
using backend_southernTravelWebsite2025.Repositories;

namespace backend_southernTravelWebsite2025.Services
{
    public interface IAttractionsService
    {
        //AttractionsResponseDto Register(AttractionsCreateDto dto);
        Task<AttractionsResponseDto?> GetAttractions(int id);
    }

    public class AttractionsService : IAttractionsService
    {
        private readonly IAttractionsRepository _repo;

        public AttractionsService(IAttractionsRepository repo)
        {
            _repo = repo;
        }

        public async Task<AttractionsResponseDto?> GetAttractions(int id)
        {
            var a = await _repo.GetById(id);
            if (a is null) return null;

            return new AttractionsResponseDto
            {
                Id = a.Id,
                Title = a.Title,
                Category = a.Category,
                Description = a.Description,
                MainImageUrl = a.MainImageUrl,
                Location = a.Location,
                Tag_1 = a.Tag_1,
                Tag_2 = a.Tag_2
            };
        }
    }
}

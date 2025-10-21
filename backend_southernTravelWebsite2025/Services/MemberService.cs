using backend_southernTravelWebsite2025.DTOs;
using backend_southernTravelWebsite2025.Models.Entities;
using backend_southernTravelWebsite2025.Repositories;

namespace backend_southernTravelWebsite2025.Services
{
    public interface IMemberService
    {
        MemberResponseDto Register(MemberCreateDto dto);
        MemberResponseDto? GetMember(int id);
    }

    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _repo;

        public MemberService(IMemberRepository repo)
        {
            _repo = repo;
        }

        public MemberResponseDto Register(MemberCreateDto dto)
        {
            var member = new Member
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password), // 密碼加密
                PhoneNumber = dto.PhoneNumber,
                Birthday = dto.Birthday
            };

            var created = _repo.Add(member);

            return new MemberResponseDto
            {
                Id = created.Id,
                Name = created.Name,
                Email = created.Email,
                PhoneNumber = created.PhoneNumber,
                Birthday = created.Birthday
            };
        }

        public MemberResponseDto? GetMember(int id)
        {
            var member = _repo.GetById(id);
            if (member == null) return null;

            return new MemberResponseDto
            {
                Id = member.Id,
                Name = member.Name,
                Email = member.Email,
                PhoneNumber = member.PhoneNumber,
                Birthday = member.Birthday
            };
        }
    }
}

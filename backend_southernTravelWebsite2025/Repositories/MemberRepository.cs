using backend_southernTravelWebsite2025.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend_southernTravelWebsite2025.Repositories
{
    public interface IMemberRepository
    {
        Member Add(Member member);
        Member? GetById(int id);
    }

    public class MemberRepository : IMemberRepository
    {
        private readonly List<Member> _members = new(); // 先用記憶體模擬，之後再改成 DB

        public Member Add(Member member)
        {
            member.Id = _members.Count + 1;
            _members.Add(member);
            return member;
        }

        public Member? GetById(int id)
        {
            return _members.FirstOrDefault(m => m.Id == id);
        }
    }
}

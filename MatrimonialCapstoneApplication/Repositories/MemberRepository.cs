using MatrimonialCapstoneApplication.Context;
using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Modals;
using Microsoft.EntityFrameworkCore;

namespace MatrimonialCapstoneApplication.Repositories
{
    public class MemberRepository : BaseRepository<Member>, IMemberRepository
    {
        MatrimonialContext _context;
        public MemberRepository(MatrimonialContext context) : base(context)
        {
            _context = context; 
        }
        public async Task<Member> Get(string Email)
        {
            var allMember = await _context.Set<Member>().ToListAsync();
            var res = allMember.FirstOrDefault(m => m.Email == Email);
            if (res == null) return null;
            return res;
        }
    }
}

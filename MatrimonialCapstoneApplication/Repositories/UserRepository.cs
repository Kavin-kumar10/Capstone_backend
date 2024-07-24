using MatrimonialCapstoneApplication.Context;
using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Modals;
using Microsoft.EntityFrameworkCore;

namespace MatrimonialCapstoneApplication.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        MatrimonialContext _context;
        public UserRepository(MatrimonialContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> Get(string Email)
        {
            var allMember = await _context.Set<User>().ToListAsync();
            var res = allMember.FirstOrDefault(m => m.Email == Email);
            if (res == null) return null;
            return res;
        }
    }
}

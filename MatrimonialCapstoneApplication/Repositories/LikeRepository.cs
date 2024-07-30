using MatrimonialCapstoneApplication.Context;
using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace MatrimonialCapstoneApplication.Repositories
{
    public class LikeRepository : BaseRepository<Like>, ILikeRepository
    {
        MatrimonialContext _context;
        public LikeRepository(MatrimonialContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Like>> GetLikesByMemberId(int memberId)
        {
            var result = await _context.Likes
                .Where(l => l.LikedById == memberId)
                .ToListAsync(); 
            return result;
        }
    }
}

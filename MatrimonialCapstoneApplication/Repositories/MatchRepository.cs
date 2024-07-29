using MatrimonialCapstoneApplication.Context;
using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace MatrimonialCapstoneApplication.Repositories
{
    public class MatchRepository : BaseRepository<Match>, IMatchesRepository
    {
        MatrimonialContext _context;
        public MatchRepository(MatrimonialContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Match>> GetMatchesWithMemberId(int memberId)
        {
            return await _context.Match
                .Include(m => m.FromProfile)
                .Include(m => m.ToProfile)
                .Where(m => m.FromProfileId == memberId || m.ToProfileId == memberId)
                .ToListAsync();
        }

    }
}

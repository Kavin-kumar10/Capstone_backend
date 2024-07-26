using MatrimonialCapstoneApplication.Context;
using MatrimonialCapstoneApplication.Models;

namespace MatrimonialCapstoneApplication.Repositories
{
    public class MatchRepository : BaseRepository<Match>
    {
        public MatchRepository(MatrimonialContext context) : base(context)
        {
        }
    }
}

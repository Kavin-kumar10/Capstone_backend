using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Models;

namespace MatrimonialCapstoneApplication.Services
{
    public class MatchServices : BaseServices<Match>
    {
        public MatchServices(IRepository<int, Match> repo) : base(repo)
        {
        }
    }
}
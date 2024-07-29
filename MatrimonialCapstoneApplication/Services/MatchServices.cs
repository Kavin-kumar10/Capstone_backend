using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Models;

namespace MatrimonialCapstoneApplication.Services
{
    public class MatchServices : BaseServices<Match>, IMatchesServices
    {
        IMatchesRepository _matchesRepository;
        public MatchServices(IRepository<int, Match> repo,IMatchesRepository matchesRepository) : base(repo)
        {
            _matchesRepository = matchesRepository;
        }

        public async Task<IEnumerable<Match>> GetMatchesWithMemberId(int MemberId)
        {
            var result = await _matchesRepository.GetMatchesWithMemberId(MemberId);   
            return result;
        }
    }
}
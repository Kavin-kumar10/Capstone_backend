using MatrimonialCapstoneApplication.Models;

namespace MatrimonialCapstoneApplication.Interfaces
{
    public interface IMatchesRepository
    {
        public Task<IEnumerable<Match>> GetMatchesWithMemberId(int MemberId);
    }
}

using MatrimonialCapstoneApplication.Models;

namespace MatrimonialCapstoneApplication.Interfaces
{
    public interface IMatchesServices
    {
        public Task<IEnumerable<Match>> GetMatchesWithMemberId(int MemberId);
    }
}

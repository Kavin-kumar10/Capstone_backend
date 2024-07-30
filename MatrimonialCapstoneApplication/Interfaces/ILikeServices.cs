using MatrimonialCapstoneApplication.Models;

namespace MatrimonialCapstoneApplication.Interfaces
{
    public interface ILikeServices
    {
        public Task<IEnumerable<Like>> GetLikesWithMemberId(int memberId);
    }
}

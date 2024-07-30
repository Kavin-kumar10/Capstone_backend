using MatrimonialCapstoneApplication.Models;

namespace MatrimonialCapstoneApplication.Interfaces
{
    public interface ILikeRepository
    {
        public Task<IEnumerable<Like>> GetLikesByMemberId(int memberId);
    }
}

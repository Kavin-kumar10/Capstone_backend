using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Models;

namespace MatrimonialCapstoneApplication.Services
{
    public class LikeServices : BaseServices<Like>, ILikeServices
    {
        private ILikeRepository _repo;
        public LikeServices(IRepository<int, Like> repo,ILikeRepository repository) : base(repo)
        {
            _repo = repository;
        }

        public async Task<IEnumerable<Like>> GetLikesWithMemberId(int memberId)
        {
            var result = await _repo.GetLikesByMemberId(memberId);
            return result;
        }
    }
}

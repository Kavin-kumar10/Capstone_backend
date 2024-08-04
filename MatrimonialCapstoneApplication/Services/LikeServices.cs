using MatrimonialCapstoneApplication.Exceptions.LikeDuplicateExceptions;
using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Models;

namespace MatrimonialCapstoneApplication.Services
{
    public class LikeServices : BaseServices<Like>, ILikeServices
    {
        private ILikeRepository _repo;
        private IRepository<int, Like> _likeRepository;
        public LikeServices(IRepository<int, Like> repo,ILikeRepository repository) : base(repo)
        {
            _repo = repository;
            _likeRepository = repo;
        }

        public async Task<IEnumerable<Like>> GetLikesWithMemberId(int memberId)
        {
            var result = await _repo.GetLikesByMemberId(memberId);
            return result;
        }

        public override async Task<Like> Create(Like Entity)
        {
            var allLike = await _likeRepository.Get();
            var duplicate = allLike.FirstOrDefault((l)=>l.LikedId == Entity.LikedId && l.LikedById == Entity.LikedById);
            if (duplicate != null) {
                throw new LikeDuplicateException();
            }
            var result = await _likeRepository.Create(Entity);
            return result;
        }
    }
}

using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Models;

namespace MatrimonialCapstoneApplication.Services
{
    public class LikeServices : BaseServices<Like>
    {
        public LikeServices(IRepository<int, Like> repo) : base(repo)
        {
        }
    }
}

using MatrimonialCapstoneApplication.Context;
using MatrimonialCapstoneApplication.Models;

namespace MatrimonialCapstoneApplication.Repositories
{
    public class LikeRepository : BaseRepository<Like>
    {
        public LikeRepository(MatrimonialContext context) : base(context)
        {
        }
    }
}

using MatrimonialCapstoneApplication.Context;
using MatrimonialCapstoneApplication.Models;

namespace MatrimonialCapstoneApplication.Repositories
{
    public class PictureRepository : BaseRepository<Picture>
    {
        public PictureRepository(MatrimonialContext context) : base(context)
        {
        }
    }
}

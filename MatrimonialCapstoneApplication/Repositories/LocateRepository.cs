using MatrimonialCapstoneApplication.Context;
using MatrimonialCapstoneApplication.Models;

namespace MatrimonialCapstoneApplication.Repositories
{
    public class LocateRepository : BaseRepository<Locate>
    {
        public LocateRepository(MatrimonialContext context) : base(context)
        {
        }
    }
}

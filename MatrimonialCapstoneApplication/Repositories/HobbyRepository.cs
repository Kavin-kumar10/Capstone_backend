using MatrimonialCapstoneApplication.Context;
using MatrimonialCapstoneApplication.Models;

namespace MatrimonialCapstoneApplication.Repositories
{
    public class HobbyRepository : BaseRepository<Hobby>
    {
        public HobbyRepository(MatrimonialContext context) : base(context)
        {
        }
    }
}

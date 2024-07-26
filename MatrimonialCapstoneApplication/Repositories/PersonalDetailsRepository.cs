using MatrimonialCapstoneApplication.Context;
using MatrimonialCapstoneApplication.Models;

namespace MatrimonialCapstoneApplication.Repositories
{
    public class PersonalDetailsRepository : BaseRepository<PersonalDetails>
    {
        public PersonalDetailsRepository(MatrimonialContext context) : base(context)
        {
        }
    }
}

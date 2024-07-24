using MatrimonialCapstoneApplication.Context;
using MatrimonialCapstoneApplication.Models;

namespace MatrimonialCapstoneApplication.Repositories
{
    public class VerificationRepository : BaseRepository<Verification>
    {
        public VerificationRepository(MatrimonialContext context) : base(context)
        {
        }
    }
}

using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Models;

namespace MatrimonialCapstoneApplication.Services
{
    public class VerificationServices : BaseServices<Verification>
    {
        public VerificationServices(IRepository<int, Verification> repo) : base(repo)
        {
        }
    }
}

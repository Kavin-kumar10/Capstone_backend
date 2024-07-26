using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Models;

namespace MatrimonialCapstoneApplication.Services
{
    public class LocateService : BaseServices<Locate>
    {
        public LocateService(IRepository<int, Locate> repo) : base(repo)
        {
        }
    }
}

using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Models;

namespace MatrimonialCapstoneApplication.Services
{
    public class DailyLogServices : BaseServices<DailyLog>
    {
        public DailyLogServices(IRepository<int, DailyLog> repo) : base(repo)
        {
        }
    }
}

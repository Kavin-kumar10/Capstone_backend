using MatrimonialCapstoneApplication.Context;
using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Models;

namespace MatrimonialCapstoneApplication.Repositories
{
    public class DailyLogsRepository : BaseRepository<DailyLog>
    {
        public DailyLogsRepository(MatrimonialContext context) : base(context)
        {
        }
    }
}

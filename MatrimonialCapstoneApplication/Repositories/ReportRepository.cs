using MatrimonialCapstoneApplication.Context;
using MatrimonialCapstoneApplication.Models;

namespace MatrimonialCapstoneApplication.Repositories
{
    public class ReportRepository : BaseRepository<Report>
    {
        public ReportRepository(MatrimonialContext context) : base(context)
        {
        }
    }
}

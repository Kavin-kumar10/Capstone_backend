using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Models;

namespace MatrimonialCapstoneApplication.Services
{
    public class ReportServices : BaseServices<Report>
    {
        public ReportServices(IRepository<int, Report> repo) : base(repo)
        {
        }
    }
}

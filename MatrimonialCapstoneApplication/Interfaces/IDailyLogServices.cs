using MatrimonialCapstoneApplication.Models;

namespace MatrimonialCapstoneApplication.Interfaces
{
    public interface IDailyLogServices
    {
        public Task<DailyLog> RefreshCount(int MemberId); 
    }
}

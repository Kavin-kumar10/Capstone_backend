using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Models;

namespace MatrimonialCapstoneApplication.Services
{
    public class DailyLogServices : BaseServices<DailyLog>, IDailyLogServices
    {
        IRepository<int,DailyLog> _repository;
        public DailyLogServices(IRepository<int, DailyLog> repo, IRepository<int, DailyLog> repository) : base(repo)
        {
            _repository = repository;
        }

        public async Task<DailyLog> RefreshCount(int MemberId)
        {
            var DailyLogs = await _repository.Get();
            var requiredDailyLog = DailyLogs.FirstOrDefault((elem)=>elem.MemberId == MemberId);
            if (requiredDailyLog == null) throw new Exception("No Dailylog found please check for subscription");
            if(requiredDailyLog.Date.Date != DateTime.Now.Date)
            {
                requiredDailyLog.Date = DateTime.Now.Date;
                requiredDailyLog.CreditsCount = 5;
            }
            var result = await _repository.Update(requiredDailyLog);
            return result;
        }
    }
}

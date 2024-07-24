using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Modals;

namespace MatrimonialCapstoneApplication.Services
{
    public class MemberServices : BaseServices<Member>
    {
        public MemberServices(IRepository<int, Member> repo) : base(repo)
        {
        }
    }
}

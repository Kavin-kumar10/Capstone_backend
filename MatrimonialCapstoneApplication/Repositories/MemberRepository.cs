using MatrimonialCapstoneApplication.Context;
using MatrimonialCapstoneApplication.Modals;

namespace MatrimonialCapstoneApplication.Repositories
{
    public class MemberRepository : BaseRepository<Member>
    {
        public MemberRepository(MatrimonialContext context) : base(context)
        {
        }
    }
}

using MatrimonialCapstoneApplication.Modals;
using Microsoft.EntityFrameworkCore;

namespace MatrimonialCapstoneApplication.Interfaces
{
    public interface IMemberRepository
    {
        public Task<Member> Get(string Email);
    }
}

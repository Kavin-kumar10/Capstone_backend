using MatrimonialCapstoneApplication.Models;

namespace MatrimonialCapstoneApplication.Interfaces
{
    public interface IPersonalDetailServices
    {
        public Task<PersonalDetails> GetPersonalDetailsWithMemberId(int MemberId);
    }
}

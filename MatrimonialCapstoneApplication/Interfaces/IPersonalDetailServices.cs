using MatrimonialCapstoneApplication.Models;

namespace MatrimonialCapstoneApplication.Interfaces
{
    public interface IPersonalDetailServices
    {
        public Task<PersonalDetails> GetPersonalDetailsWithMemberId(int MemberId,string Email,string Role);
        public Task<PersonalDetails> GetPersonalDetailsWithToken(int MemberId);
    }
}

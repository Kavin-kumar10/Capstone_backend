using MatrimonialCapstoneApplication.Modals;

namespace MatrimonialCapstoneApplication.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> Get(string Email);
    }
}

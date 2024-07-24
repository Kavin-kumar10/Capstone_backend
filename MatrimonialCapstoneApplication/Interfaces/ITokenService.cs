
using MatrimonialCapstoneApplication.Modals;

namespace MatrimonialCapstoneApplication.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(Member member);
    }
}

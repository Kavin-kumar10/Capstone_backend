using EcommerceApplication.Models.DTOs.RequestDTOs;
using EcommerceApplication.Models.DTOs.ReturnDTOs;
using MatrimonialCapstoneApplication.Modals;

namespace MatrimonialCapstoneApplication.Interfaces
{
    public interface IUserServices
    {
        public Task<User> Register(RegisterRequestDTO registerRequestDTO);
        public Task<LoginReturnDTO> Login(LoginRequestDTO loginRequestDTO);

    }
}

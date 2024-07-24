using MatrimonialCapstoneApplication.Models.Enums;

namespace EcommerceApplication.Models.DTOs.ReturnDTOs
{
    public class LoginReturnDTO
    {
        public string Token { get; set; }
        public string MemberId { get; set; }
        public RoleEnum Role { get; set; }
    }
}

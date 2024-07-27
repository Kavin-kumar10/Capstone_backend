using MatrimonialCapstoneApplication.Models.Enums;
using System.Numerics;

namespace MatrimonialCapstoneApplication.Models.DTOs.ReturnDTOs
{
    public class ActivateReturnDTO
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public RoleEnum Role { get; set; }
        public Membershipenum Membership { get; set; }
    }
}

using MatrimonialCapstoneApplication.Models.Enums;
using System.Numerics;

namespace MatrimonialCapstoneApplication.Models.DTOs.RequestDTOs
{
    public class ActivationReqDTO
    {
        public int MemberId { get; set; }
        public RoleEnum Role { get; set; }
        public Membershipenum Plan { get; set; }
    }
}

using MatrimonialCapstoneApplication.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MatrimonialCapstoneApplication.Modals
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public RoleEnum Role { get; set; } = RoleEnum.User;
        public Membershipenum Membership { get; set; } = Membershipenum.Free;


    }
}

using MatrimonialCapstoneApplication.Models;
using MatrimonialCapstoneApplication.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

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
        public string? Gender { get; set; }
        public string? MemberName { get; set; }
        public string? Relation { get; set; }
        public string? PersonName { get; set; }
        public string? About { get; set; }
        public int? Height { get; set; }
        public string? MotherTongue { get; set; }
        public string? Caste { get; set; }
        public string? Religion { get; set; }
        public string? MaritalStatus { get; set; }
        public string? Disabilities { get; set; }
        public bool? AllowLocation { get; set; }
        public bool? IsVerified { get; set; }
        public string? ProfilePic { get; set; }
        public List<Picture>? Pictures { get; set; }
        public string? FamilyType { get; set; }
        public string? FamilyValue { get; set; }
        public string? FamilyStatus { get; set; }
        public string? ProfessionName { get; set; }
        public string? Education { get; set; }
        public List<Hobby>? Hobby { get; set; }
        public string? AnnualIncome { get; set; }
        public string? Location { get; set; }
        public List<Models.Match>? Matches { get; set; }
        public List<Like>? Likes { get; set; }
        public List<Report>? Reports { get; set; }
    }
}

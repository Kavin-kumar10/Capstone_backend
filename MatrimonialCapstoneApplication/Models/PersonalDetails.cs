using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatrimonialCapstoneApplication.Models
{
    public class PersonalDetails
    {
        [Key]
        public int PersonalDetailsId { get; set; }

        [ForeignKey("MemberId")]
        public int MemberId { get; set; }
        public string? FamilyType { get; set; }
        public string? Mobile {  get; set; }
        public string? FamilyValue { get; set; }
        public string? FamilyStatus { get; set; }
        public string? Education { get; set; }
        public string? ProfessionName { get; set; }
        public Locate? Location { get; set; }
        public string? AnnualIncome { get; set; }
        public List<Picture>? Pictures { get; set; }
    }
}

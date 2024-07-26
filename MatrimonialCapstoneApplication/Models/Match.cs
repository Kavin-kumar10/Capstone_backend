using MatrimonialCapstoneApplication.Modals;
using System.ComponentModel.DataAnnotations;

namespace MatrimonialCapstoneApplication.Models
{
    public class Match
    {
        [Key]
        public int MatchId { get; set; }

        [Required]
        public int FromProfileId { get; set; }  // Foreign key to the profile initiating the match

        [Required]
        public int ToProfileId { get; set; }  // Foreign key to the profile being matched

        [Required, MaxLength(50)]
        public string Status { get; set; }  // Status of the match (e.g., Pending, Accepted, Rejected)

        public string? Message { get; set; }  // Optional message associated with the match

        [Required]
        public DateTime MatchDate { get; set; } = new DateTime();  // Date when the match was created

        public Member FromProfile { get; set; }  // Navigation property

        public Member ToProfile { get; set; }  // Navigation property
    }
}

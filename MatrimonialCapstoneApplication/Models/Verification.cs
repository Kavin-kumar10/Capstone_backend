using System.ComponentModel.DataAnnotations;

namespace MatrimonialCapstoneApplication.Models
{
    public class Verification
    {
        [Key]
        public int VerificationId { get; set; }

        public int AdminId { get; set; }

        public int UserId { get; set; }

        public DateTime ScheduledTime { get; set; }

        public string Status { get; set; }
    }
}

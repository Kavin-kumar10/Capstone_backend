using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace MatrimonialCapstoneApplication.Modals
{
    public class User
    {
        [Key]
        public int MemberId { get; set; }
        public string Email { get; set; }
        public Byte[] Password { get; set; }
        public Byte[] HashedPassword { get; set; }

        [ForeignKey("MemberId")]
        public Member Member { get; set; }
        public string Status { get; set; } = "Disabled";
    }
}

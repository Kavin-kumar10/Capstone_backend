using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatrimonialCapstoneApplication.Models
{
    public class DailyLog
    {
        [Key]
        public int DailyLogId {  get; set; }
        [ForeignKey("MemberId")]
        public int MemberId { get; set; }
        public DateOnly Date {  get; set; }
        public int CreditsCount { get; set; }
    }
}

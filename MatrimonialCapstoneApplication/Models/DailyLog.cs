using MatrimonialCapstoneApplication.Modals;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MatrimonialCapstoneApplication.Models
{
    public class DailyLog
    {
        [Key]
        public int DailyLogId {  get; set; }
        public DateTime Date {  get; set; }
        public int CreditsCount { get; set; }
        public int MemberId { get; set; }
        [JsonIgnore]
        public Member? Member { get; set; }
    }
}

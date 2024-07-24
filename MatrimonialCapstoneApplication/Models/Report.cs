using MatrimonialCapstoneApplication.Modals;
using System.ComponentModel.DataAnnotations;

namespace MatrimonialCapstoneApplication.Models
{
    public class Report
    {
        [Key]
        public int ReportId { get; set; }

        public int ReportedById { get; set; }     

        public int ReportedAccountId { get; set; }    

        public int? AdminHandledId { get; set; }      

        [Required, MaxLength(500)]
        public string ReportMessage { get; set; }


        public Member ReportedBy { get; set; }  // Navigation property

        public Member ReportedAccount { get; set; }  // Navigation property

        public Member? AdminHandled { get; set; }  // Navigation property (optional)
    }
}

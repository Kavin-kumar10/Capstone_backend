using MatrimonialCapstoneApplication.Modals;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MatrimonialCapstoneApplication.Models
{
    public class Picture
    {
        public int PictureId { get; set; }
        public string PictureUrl { get; set; }

        [ForeignKey("MemberId")]
        public int MemberId { get; set; }
        [JsonIgnore]
        public Member Member { get; set; }
    }
}

using MatrimonialCapstoneApplication.Modals;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MatrimonialCapstoneApplication.Models
{
    public class Picture
    {
        [Key]
        public int PictureId { get; set; }
        public string PictureUrl { get; set; }

        [ForeignKey("PersonalDetailsId")]
        public int PersonalDetailsId { get; set; }
        [JsonIgnore]
        public PersonalDetails? PersonalDetails { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MatrimonialCapstoneApplication.Models
{
    public class Locate
    {
        [Key]
        public int LocateId { get; set; }
        public double Lat {  get; set; }
        public double Long {  get; set; }
        [ForeignKey("PersonalDetailsId")]
        public int? PersonalDetailsId { get; set; }
        [JsonIgnore]
        public PersonalDetails? PersonalDetails { get; set; }
    }
}

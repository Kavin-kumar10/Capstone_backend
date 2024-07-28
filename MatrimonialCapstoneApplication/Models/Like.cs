using MatrimonialCapstoneApplication.Modals;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MatrimonialCapstoneApplication.Models
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }
        public int LikedById { get; set; }
        public int LikedId { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        [JsonIgnore]
        public Member? LikedBy { get; set; }
        [JsonIgnore]
        public Member? Liked { get; set; }
    }

}

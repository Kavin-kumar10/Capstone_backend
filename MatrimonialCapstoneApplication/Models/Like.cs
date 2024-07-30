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
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public Member? Liked { get; set; }
    }

}

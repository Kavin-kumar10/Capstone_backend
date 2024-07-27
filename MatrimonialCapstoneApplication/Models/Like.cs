using MatrimonialCapstoneApplication.Modals;
using System.ComponentModel.DataAnnotations;

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
        public Member LikedBy { get; set; }
        public Member Liked { get; set; }
    }

}

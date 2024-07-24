using MatrimonialCapstoneApplication.Modals;

namespace MatrimonialCapstoneApplication.Models
{
    public class Like
    {
        public int LikeId { get; set; }
        public int LikedById { get; set; }
        public int LikedId { get; set;}
        public DateTime CreatedAt { get; set; }
        public Member LikedBy { get; set; }  // Navigation property
        public Member Liked { get; set; }  // Navigation property
    }
}

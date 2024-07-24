namespace MatrimonialCapstoneApplication.Models
{
    public class Like
    {
        public int LikeId { get; set; }
        public int FromMemberId { get; set; }
        public int ToMemberId { get; set;}
        public DateTime CreatedAt { get; set; }
    }
}

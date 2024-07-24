using MatrimonialCapstoneApplication.Modals;
using System.Text.Json.Serialization;

namespace MatrimonialCapstoneApplication.Models
{
    public class Hobby
    {
        public int HobbyId { get; set; }
        public string HobbyName { get; set; }   
        public int MemberId { get; set; }
        [JsonIgnore]
        public Member Member { get; set; }
    }
}

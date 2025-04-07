using System.ComponentModel.DataAnnotations;

namespace UniMate2.Models.Domain
{
    public class Like
    {
        public Guid Id { get; set; }
        public User Liker { get; set; } = null!;
        public string LikerId { get; set; } = null!;
        public User Liked { get; set; } = null!;
        public string LikedId { get; set; } = null!;
        public DateTime LikedAt { get; set; }
    }
}

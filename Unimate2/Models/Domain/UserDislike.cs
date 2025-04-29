using System;

namespace UniMate2.Models.Domain
{
    public class UserDislike
    {
        public Guid Id { get; set; }
        public User DislikingUser { get; set; } = null!;
        public string DislikingUserId { get; set; } = null!;
        public User DislikedUser { get; set; } = null!;
        public string DislikedUserId { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}

using System;

namespace UniMate.Models.Domain
{
    public class ProfileView
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ViewerId { get; set; }
        public Guid ViewedUserId { get; set; }
        public DateTime ViewedAt { get; set; } = DateTime.UtcNow;
    }
}

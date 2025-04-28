using System;

namespace UniMate2.Models.Domain
{
    public class AbuseReport
    {
        public Guid Id { get; set; }
        public string ReporterId { get; set; } = string.Empty;
        public string ReportedUserId { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        // Навігаційні властивості (опціонально)
        public User ReportingUser { get; set; } = null!;
        public User ReportedUser { get; set; } = null!;
    }
}

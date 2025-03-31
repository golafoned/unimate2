using System;
using System.ComponentModel.DataAnnotations;
using UniMate2.Models.Domain.Enums;

namespace UniMate2.Models.Domain
{
    public class FriendRequest
    {
        [Key]
        public Guid Id { get; set; }
        public string RequesterId { get; set; }
        public string RecipientId { get; set; }
        public bool IsAccepted { get; set; }
        public DateTime CreatedAt { get; set; }
        
        // Navigation properties
        public User Requester { get; set; }
        public User Recipient { get; set; }
    }
}

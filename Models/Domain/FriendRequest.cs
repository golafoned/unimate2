using System.ComponentModel.DataAnnotations;
using UniMate2.Models.Domain.Enums;

namespace UniMate2.Models.Domain
{
    public class FriendRequest
    {
        [Key]
        public Guid Id { get; set; }
        public required User Sender { get; set; }
        public required User Receiver { get; set; }
        public DateTime RequestDate { get; set; }
        public required FriendRequestStatus Status { get; set; }
    }
}

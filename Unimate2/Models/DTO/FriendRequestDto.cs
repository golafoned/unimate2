using UniMate2.Models.Domain;

namespace UniMate2.Models.DTO;

public class FriendRequestDto
{
    public Guid Id { get; set; }
    public required UserDto Sender { get; set; }
    public required UserDto Receiver { get; set; }
    public required string Status { get; set; }
}

public class FriendRequestRequestDto
{
    public required string ReceiverEmail { get; set; }
}

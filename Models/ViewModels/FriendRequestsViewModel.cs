using UniMate2.Models.DTO;

namespace UniMate2.Models.ViewModels
{
    public class FriendRequestsViewModel
    {
        public List<FriendRequestDto> ReceivedRequests { get; set; } = [];
        public List<FriendRequestDto> SentRequests { get; set; } = [];
    }
}

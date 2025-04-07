using UniMate2.Models.Domain;

namespace UniMate2.Models.ViewModels
{
    public class LikeDislikeLogViewModel
    {
        public List<UserInteractionViewModel> UsersILiked { get; set; } = [];
        public List<UserInteractionViewModel> UsersIDisliked { get; set; } = [];
        public List<UserInteractionViewModel> UsersWhoLikedMe { get; set; } = [];
        public List<UserInteractionViewModel> UsersWhoDislikedMe { get; set; } = [];
    }

    public class UserInteractionViewModel
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string ProfileImageUrl { get; set; }
        public DateTime Timestamp { get; set; }
    }
}

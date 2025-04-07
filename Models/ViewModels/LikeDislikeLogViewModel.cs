using UniMate2.Models.Domain;

namespace UniMate2.Models.ViewModels
{
    public class LikeDislikeLogViewModel
    {
        public List<UserInteractionViewModel> UsersILiked { get; set; } =
            new List<UserInteractionViewModel>();
        public List<UserInteractionViewModel> UsersIDisliked { get; set; } =
            new List<UserInteractionViewModel>();
        public List<UserInteractionViewModel> UsersWhoLikedMe { get; set; } =
            new List<UserInteractionViewModel>();
        public List<UserInteractionViewModel> UsersWhoDislikedMe { get; set; } =
            new List<UserInteractionViewModel>();
    }

    public class UserInteractionViewModel
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string ProfileImageUrl { get; set; }
        public DateTime Timestamp { get; set; }
    }
}

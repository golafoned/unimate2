using UniMate2.Models.Domain;

namespace UniMate2.Repositories
{
    public interface ILikeRepository
    {
        Task<Like?> GetLikeAsync(Guid id);
        Task<List<Like>> GetAllLikesAsync();
        Task<List<string>> GetLikedUserIdsAsync(string userId);
        Task<List<string>> GetUsersWhoLikedMeIdsAsync(string userId);
        Task AddAsync(Like like);
        Task<bool> LikeExistsAsync(string likerId, string likedId);
        Task<bool> CreateLikeAsync(string likingUserId, string likedUserId);

        // New methods for the like/dislike log
        Task<List<Like>> GetUserLikesWithDetailsAsync(string userId);
        Task<List<Like>> GetLikesReceivedWithDetailsAsync(string userId);
    }
}

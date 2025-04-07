using UniMate2.Models.Domain;

namespace UniMate2.Repositories
{
    public interface IDislikeRepository
    {
        Task<UserDislike?> GetDislikeAsync(Guid id);
        Task<List<UserDislike>> GetAllDislikesAsync();
        Task<List<string>> GetDislikedUserIdsAsync(string userId);
        Task<List<string>> GetUsersWhoDislikedMeIdsAsync(string userId);
        Task AddAsync(UserDislike dislike);
        Task<bool> DislikeExistsAsync(string dislikerId, string dislikedId);
        Task<bool> CreateDislikeAsync(string dislikingUserId, string dislikedUserId);

        // New methods for the like/dislike log
        Task<List<UserDislike>> GetUserDislikesWithDetailsAsync(string userId);
        Task<List<UserDislike>> GetDislikesReceivedWithDetailsAsync(string userId);
    }
}

using UniMate2.Models.Domain;

namespace UniMate2.Repositories
{
    public interface ILikeRepository
    {
        Task<Like?> GetLikeAsync(Guid id);
        Task<List<Like>> GetAllLikesAsync();
        Task AddAsync(Like like);
        Task UpdateAsync(Like like);
        Task DeleteAsync(Like like);
        Task<bool> LikeExistsAsync(string likerId, string likedId);
    }
}

using Microsoft.EntityFrameworkCore;
using UniMate2.Data;
using UniMate2.Models.Domain;

namespace UniMate2.Repositories
{
    public class LikeRepository(ServerDbContext context) : ILikeRepository
    {
        private readonly ServerDbContext _context = context;

        public async Task<Like?> GetLikeAsync(Guid id)
        {
            return await _context.Likes.FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<List<Like>> GetAllLikesAsync()
        {
            return await _context.Likes.ToListAsync();
        }

        public async Task AddAsync(Like like)
        {
            await _context.Likes.AddAsync(like);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Like like)
        {
            _context.Likes.Update(like);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Like like)
        {
            _context.Likes.Remove(like);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> LikeExistsAsync(string likerId, string likedId)
        {
            return await _context.Likes.AnyAsync(l =>
                l.Liker.Id == likerId && l.Liked.Id == likedId
            );
        }
    }
}

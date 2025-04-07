using Microsoft.EntityFrameworkCore;
using UniMate2.Data;
using UniMate2.Models.Domain;

namespace UniMate2.Repositories;

public class FriendsRepository(ServerDbContext context) : IFriendsRepository
{
    private readonly ServerDbContext _context = context;

    public async Task<FriendRequest?> GetFriendRequestAsync(Guid id)
    {
        return await _context.FriendRequests.FindAsync(id);
    }

    public async Task AddAsync(FriendRequest friendRequest)
    {
        await _context.FriendRequests.AddAsync(friendRequest);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(FriendRequest friendRequest)
    {
        _context.FriendRequests.Update(friendRequest);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(FriendRequest friendRequest)
    {
        _context.FriendRequests.Remove(friendRequest);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> IFFriendRequestExistsAsync(string senderEmail, string receiverEmail)
    {
        var isExist = await _context.FriendRequests.AnyAsync(fr =>
            fr.Receiver.Email == receiverEmail && fr.Sender.Email == senderEmail
        );

        return isExist;
    }

    public async Task<List<FriendRequest>> GetAllUserFriendRequestsAsync(User user)
    {
        return await _context
            .FriendRequests.Where(fr => fr.Receiver.Id == user.Id || fr.Sender.Id == user.Id)
            .Include(fr => fr.Sender)
            .Include(fr => fr.Receiver)
            .ToListAsync();
    }
}

using Microsoft.EntityFrameworkCore;
using UniMate2.Data;
using UniMate2.Models.Domain;
using UniMate2.Models.Domain.Enums;
using System.Linq;

public class FriendRepository : IFriendRepository
{
    private readonly ServerDbContext _context;

    public FriendRepository(ServerDbContext context)
    {
        _context = context;
    }
    public async Task SendFriendRequest(User sender, User receiver)
    {
        var request = new FriendRequest
        {
            Sender = sender,
            Receiver = receiver,
            Status = FriendRequestStatus.Pending,
            RequestDate = DateTime.Now
    };
        _context.FriendRequests.Add(request);
        await _context.SaveChangesAsync();
    }

    public async Task<List<User>> GetFriendsForUser(string userId)
    {
        var rawFriends = await _context.FriendRequests
            .Where(fr =>
               (fr.Sender.Id == userId || fr.Receiver.Id == userId) &&
               fr.Status == FriendRequestStatus.Accepted)
           .Select(fr => fr.Sender.Id == userId ? fr.Receiver : fr.Sender)
           .ToListAsync(); 

        return rawFriends.DistinctBy(u => u.Id).ToList(); 

    }
}

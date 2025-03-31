using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniMate2.Data; // Make sure this matches the namespace in ServerDbContext
using UniMate2.Models.Domain;
using UniMate2.Models.Domain.Enums; // Add this import for FriendshipStatus

namespace UniMate2.Repositories
{
    public class FriendRequestRepository : IFriendRequestRepository
    {
        private readonly ServerDbContext _context;

        public FriendRequestRepository(ServerDbContext context)  // Updated parameter type
        {
            _context = context;
        }

        public async Task<FriendRequest> CreateFriendRequestAsync(string requesterId, string recipientId)
        {
            var friendRequest = new FriendRequest
            {
                Id = Guid.NewGuid(),
                RequesterId = requesterId,
                RecipientId = recipientId,
                IsAccepted = false,
                CreatedAt = DateTime.UtcNow
            };

            await _context.FriendRequests.AddAsync(friendRequest);
            await _context.SaveChangesAsync();
            
            return friendRequest;
        }

        public async Task<IdentityResult> AcceptFriendRequestAsync(Guid requestId)
        {
            var friendRequest = await _context.FriendRequests.FindAsync(requestId);
            
            if (friendRequest == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Friend request not found." });
            }

            friendRequest.IsAccepted = true;
            await _context.SaveChangesAsync();
            
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteFriendRequestAsync(Guid requestId)
        {
            var friendRequest = await _context.FriendRequests.FindAsync(requestId);
            
            if (friendRequest == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Friend request not found." });
            }

            _context.FriendRequests.Remove(friendRequest);
            await _context.SaveChangesAsync();
            
            return IdentityResult.Success;
        }

        public async Task<List<FriendRequest>> GetPendingRequestsForUserAsync(string userId)
        {
            // Make sure to eagerly load the related entities
            var requests = await _context.FriendRequests
                .Include(fr => fr.Requester)
                .Include(fr => fr.Recipient)
                .Where(fr => fr.RecipientId == userId && !fr.IsAccepted)
                .ToListAsync();
            
            // Debug logging - can be removed later
            Console.WriteLine($"Found {requests.Count} pending requests for user {userId}");
            foreach (var request in requests)
            {
                Console.WriteLine($"Request ID: {request.Id}, From: {request.RequesterId}, To: {request.RecipientId}, IsAccepted: {request.IsAccepted}");
            }
            
            return requests;
        }

        public async Task<List<FriendRequest>> GetFriendsForUserAsync(string userId)
        {
            return await _context.FriendRequests
                .Include(fr => fr.Requester)
                .Include(fr => fr.Recipient)
                .Where(fr => (fr.RequesterId == userId || fr.RecipientId == userId) && fr.IsAccepted)
                .ToListAsync();
        }

        public async Task<FriendRequest> GetFriendRequestAsync(string requesterId, string recipientId)
        {
            return await _context.FriendRequests
                .FirstOrDefaultAsync(fr => fr.RequesterId == requesterId && fr.RecipientId == recipientId);
        }

        public async Task<bool> DoesFriendRequestExistAsync(string requesterId, string recipientId)
        {
            // Check if there's already a friendship or pending request in either direction
            return await _context.FriendRequests
                .AnyAsync(fr => (
                    // Check for any relationship between these users in either direction
                    (fr.RequesterId == requesterId && fr.RecipientId == recipientId) || 
                    (fr.RequesterId == recipientId && fr.RecipientId == requesterId)
                ));
        }

        // Add this new method to get friendship status between two users
        public async Task<FriendshipStatus> GetFriendshipStatusAsync(string userId1, string userId2)
        {
            var relationship = await _context.FriendRequests
                .FirstOrDefaultAsync(fr => 
                    (fr.RequesterId == userId1 && fr.RecipientId == userId2) || 
                    (fr.RequesterId == userId2 && fr.RecipientId == userId1));
            
            if (relationship == null)
            {
                return FriendshipStatus.None;
            }
            else if (relationship.IsAccepted)
            {
                return FriendshipStatus.Friends;
            }
            else if (relationship.RequesterId == userId1)
            {
                return FriendshipStatus.RequestSent;
            }
            else
            {
                return FriendshipStatus.RequestReceived;
            }
        }

        public async Task<IdentityResult> RemoveFriendshipAsync(string userId, string friendId)
        {
            try
            {
                var friendRequest = await _context.FriendRequests
                    .FirstOrDefaultAsync(fr => 
                        ((fr.RequesterId == userId && fr.RecipientId == friendId) || 
                         (fr.RequesterId == friendId && fr.RecipientId == userId)) && 
                        fr.IsAccepted);
                
                if (friendRequest == null)
                {
                    return IdentityResult.Failed(new IdentityError { Description = "Friendship not found." });
                }

                _context.FriendRequests.Remove(friendRequest);
                await _context.SaveChangesAsync();
                
                return IdentityResult.Success;
            }
            catch (Exception ex)
            {
                return IdentityResult.Failed(new IdentityError { Description = $"Failed to remove friendship: {ex.Message}" });
            }
        }

        public async Task<FriendRequest> GetFriendRequestByIdAsync(Guid requestId)
        {
            return await _context.FriendRequests
                .Include(fr => fr.Requester)
                .Include(fr => fr.Recipient)
                .FirstOrDefaultAsync(fr => fr.Id == requestId);
        }
    }
}

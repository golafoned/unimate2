using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniMate2.Models.Domain;
using UniMate2.Models.Domain.Enums;

namespace UniMate2.Repositories
{
    public interface IFriendRequestRepository
    {
        Task<FriendRequest> CreateFriendRequestAsync(string requesterId, string recipientId);
        Task<IdentityResult> AcceptFriendRequestAsync(Guid requestId);
        Task<IdentityResult> DeleteFriendRequestAsync(Guid requestId);
        Task<List<FriendRequest>> GetPendingRequestsForUserAsync(string userId);
        Task<List<FriendRequest>> GetFriendsForUserAsync(string userId);
        Task<FriendRequest> GetFriendRequestAsync(string requesterId, string recipientId);
        Task<bool> DoesFriendRequestExistAsync(string requesterId, string recipientId);
        Task<IdentityResult> RemoveFriendshipAsync(string userId, string friendId);
        Task<FriendshipStatus> GetFriendshipStatusAsync(string userId1, string userId2);
        Task<FriendRequest> GetFriendRequestByIdAsync(Guid requestId);
    }
}

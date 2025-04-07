using UniMate2.Models.Domain;

namespace UniMate2.Repositories
{
    public interface IFriendsRepository
    {
        Task<bool> IFFriendRequestExistsAsync(string senderEmail, string receiverEmail);
        Task<FriendRequest?> GetFriendRequestAsync(Guid id);
        Task<List<FriendRequest>> GetAllUserFriendRequestsAsync(User user);
        Task AddAsync(FriendRequest friendRequest);
        Task UpdateAsync(FriendRequest friendRequest);
        Task DeleteAsync(FriendRequest friendRequest);
    }
}

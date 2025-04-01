using UniMate2.Models.Domain;

public interface IFriendRepository
{
    Task SendFriendRequest(User sender, User receiver);
    Task<List<User>> GetFriendsForUser(string userId);
}

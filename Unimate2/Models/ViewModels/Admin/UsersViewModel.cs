using UniMate2.Models.Domain;

namespace UniMate2.Models.ViewModels.Admin
{
    public class UsersViewModel
    {
        public List<User> Users { get; set; } = new List<User>();
        public string SortOrder { get; set; } = "none";
        public Dictionary<string, int> LikesReceived { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> LikesGiven { get; set; } = new Dictionary<string, int>();
    }
}

using UniMate2.Models.Domain;

namespace UniMate2.Models.ViewModels.Admin
{
    public class EditUserViewModel
    {
        public User User { get; set; } = null!;
        public List<string> UserRoles { get; set; } = new List<string>();
        public List<string> AllRoles { get; set; } = new List<string>();
    }
}

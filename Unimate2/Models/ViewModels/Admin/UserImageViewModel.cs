namespace UniMate2.Models.ViewModels.Admin
{
    public class UserImageViewModel
    {
        public Guid ImageId { get; set; }
        public string UserId { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string ImagePath { get; set; } = null!;
    }
}

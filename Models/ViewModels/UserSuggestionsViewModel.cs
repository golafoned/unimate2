using UniMate2.Models.DTO;

namespace UniMate2.Models.ViewModels
{
    public class UserSuggestionsViewModel
    {
        public List<UserDto> Suggestions { get; set; } = new List<UserDto>();
    }
}

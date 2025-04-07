using UniMate2.Models.DTO;

namespace UniMate2.Models.ViewModels
{
    public class UserSuggestionsViewModel
    {
        public List<UserDto> Suggestions { get; set; } = [];
        public string SearchTerm { get; set; } = string.Empty;
    }
}

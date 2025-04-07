using Microsoft.AspNetCore.Identity;
using UniMate2.Models.Domain.Enums;

namespace UniMate2.Models.Domain
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public string? University { get; set; } = string.Empty;
        public string? Faculty { get; set; } = string.Empty;
        public Gender? Gender { get; set; }
        public Orientation? Orientation { get; set; }
        public AddictionStatus? IsSmoking { get; set; }
        public AddictionStatus? IsDrinking { get; set; }
        public LookingForEnum? LookingFor { get; set; }
        public PersonalityType? PersonalityType { get; set; }
        public ZodiakSign? ZodiakSign { get; set; }
        public string? Bio { get; set; } = string.Empty;
        public List<User>? Friends { get; set; } = [];
        public List<UserImage>? Images { get; set; } = [];
    }
}

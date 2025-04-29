using UniMate2.Models.Domain;
using UniMate2.Models.Domain.Enums;

namespace UniMate2.Models.DTO;

public class UserDto
{
    public required string Id { get; set; }
    public required string Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string University { get; set; } = string.Empty;
    public string Faculty { get; set; } = string.Empty;
    public Gender? Gender { get; set; }
    public Orientation? Orientation { get; set; }
    public ZodiakSign? ZodiakSign { get; set; }
    public AddictionStatus? IsSmoking { get; set; }
    public AddictionStatus? IsDrinking { get; set; }
    public PersonalityType? PersonalityType { get; set; }
    public LookingForEnum? LookingFor { get; set; }
    public string Bio { get; set; } = string.Empty;
    public string? ProfileImagePath { get; set; }
    public List<UserDto> Friends { get; set; } = [];
    public List<UserImageDto>? Images { get; set; }
    public string? ProfilePicture { get; set; } // Added missing property
}

using UniMate2.Models.Domain.Enums;

namespace UniMate2.Models.DTO;

public class UserDto
{
    public required string Email { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required DateTime BirthDate { get; set; }
    public required string University { get; set; }
    public required string Faculty { get; set; }
    public Gender? Gender { get; set; }
    public Orientation? Orientation { get; set; }
    public ZodiakSign? ZodiakSign { get; set; }
    public AddictionStatus? IsSmoking { get; set; }
    public AddictionStatus? IsDrinking { get; set; }
    public PersonalityType? PersonalityType { get; set; }
    public LookingForEnum? LookingFor { get; set; }
    public string? Bio { get; set; }
    public List<UserDto> Friends { get; set; } = [];
    public List<UserImageDto> Images { get; set; } = [];
}

using System.ComponentModel.DataAnnotations;
using UniMate2.Models.Domain.Enums;

namespace UniMate2.Models.DTO;

public class UpdateUserDto
{
    public string? University { get; set; }
    public string? Faculty { get; set; }
    public Gender? Gender { get; set; }
    public Orientation? Orientation { get; set; }
    public ZodiakSign? ZodiakSign { get; set; }
    public AddictionStatus? IsSmoking { get; set; }
    public AddictionStatus? IsDrinking { get; set; }
    public PersonalityType? PersonalityType { get; set; }
    public LookingForEnum? LookingFor { get; set; }
    public string? Bio { get; set; }
}

// c:\Storage\projs\UniMate2\Models\DTO\UpdateUserDto.cs
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using UniMate2.Models.Domain.Enums;

namespace UniMate2.Models.DTO
{
    public class UpdateUserDto
    {
        [Required(ErrorMessage = "First name is required")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public Gender? Gender { get; set; }

        [Required(ErrorMessage = "Orientation is required")]
        public Orientation? Orientation { get; set; }

        [Required(ErrorMessage = "University is required")]
        public string? University { get; set; }

        [Required(ErrorMessage = "Faculty is required")]
        public string? Faculty { get; set; }

        public List<string>? Languages { get; set; } = new List<string>();

        [Required(ErrorMessage = "Smoking status is required")]
        public AddictionStatus? IsSmoking { get; set; }

        [Required(ErrorMessage = "Drinking status is required")]
        public AddictionStatus? IsDrinking { get; set; }

        public LookingForEnum? LookingFor { get; set; }

        public string? PersonalityType { get; set; }

        [StringLength(500, ErrorMessage = "Bio should not exceed 500 characters")]
        public string? Bio { get; set; }

        public ZodiakSign? ZodiakSign { get; set; }
        public List<IFormFile>? ImageFiles { get; set; } = new List<IFormFile>();

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
    }
}

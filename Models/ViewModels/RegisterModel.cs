using System.ComponentModel.DataAnnotations;
using UniMate2.Models.Domain.Enums;

namespace UniMate2.Models.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "First name is required")]
        [StringLength(100, ErrorMessage = "First name cannot be longer than 100 characters")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(100, ErrorMessage = "Last name cannot be longer than 100 characters")]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(
            100,
            MinimumLength = 6,
            ErrorMessage = "Password must be at least 6 characters long"
        )]
        public required string Password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public required string Email { get; set; }
        public DateTime? BirthDate { get; set; }

        [StringLength(100, ErrorMessage = "University cannot be longer than 100 characters")]
        public string? University { get; set; }

        [StringLength(100, ErrorMessage = "Faculty cannot be longer than 100 characters")]
        public string? Faculty { get; set; }

        public Gender? Gender { get; set; }

        public Orientation? Orientation { get; set; }

        public AddictionStatus? IsSmoking { get; set; }

        public AddictionStatus? IsDrinking { get; set; }

        public LookingForEnum? LookingFor { get; set; }

        public string? Bio { get; set; }
    }
}

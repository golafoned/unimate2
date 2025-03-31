using System.ComponentModel.DataAnnotations;

namespace UniMate2.Models.ViewModels;

public class LoginModel
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    [MinLength(6)]
    public required string Password { get; set; }

    public bool RememberMe { get; set; }
}

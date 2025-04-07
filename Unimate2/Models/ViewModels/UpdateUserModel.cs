using System.ComponentModel.DataAnnotations;

namespace UniMate2.Models.ViewModels;

public class UpdateUserModel
{
    [MaxLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
    [MinLength(3, ErrorMessage = "Name cannot be shorter than 3 characters")]
    public string? Name { get; set; }
}

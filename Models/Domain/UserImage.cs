using System.ComponentModel.DataAnnotations;
using UniMate2.Models.Domain;

public class UserImage
{
    [Key]
    public Guid Id { get; set; }
    public User User { get; set; } = new User();
    public int SerialNumber { get; set; }
    public string ImagePath { get; set; } = string.Empty;
}

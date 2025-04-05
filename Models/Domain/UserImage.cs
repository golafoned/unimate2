using System.ComponentModel.DataAnnotations;

namespace UniMate2.Models.Domain
{
    public class UserImage
    {
        [Key]
        public Guid Id { get; set; }

        public User? User { get; set; }

        [Required]
        public required string ImagePath { get; set; }

        public int SerialNumber { get; set; }
    }
}

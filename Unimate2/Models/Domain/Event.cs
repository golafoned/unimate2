using System.ComponentModel.DataAnnotations;

namespace UniMate2.Models.Domain;

public class Event
{
    [Key]
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public required string Location { get; set; }
}

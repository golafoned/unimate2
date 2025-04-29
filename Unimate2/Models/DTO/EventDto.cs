using System;

namespace UniMate2.Models.DTO;

public class EventDto
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public required string Location { get; set; }
}

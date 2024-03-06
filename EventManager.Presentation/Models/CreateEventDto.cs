﻿namespace EventManager.Presentation.Models;

public class CreateEventDto
{
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateTime Date { get; set; }
    public string Location { get; set; } = default!;
}

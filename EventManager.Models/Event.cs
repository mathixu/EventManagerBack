namespace EventManager.Models;

public class Event
{
    /// <summary>
    /// Unique identifier for the event
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Title of the event
    /// </summary>
    public string Title { get; set; } = default!;

    /// <summary>
    /// Description of the event
    /// </summary>
    public string Description { get; set; } = default!;

    /// <summary>
    /// Date and time of the event
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Location of the event
    /// </summary>
    public string Location { get; set; } = default!;
}

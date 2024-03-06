using EventManager.Models;

namespace EventManager.Business.Contracts;

public interface IEventBusiness
{
    /// <summary>
    /// Create a new event
    /// </summary>
    Task<Event> CreateAsync(Event entity);

    /// <summary>
    /// List all events or filter by date
    /// </summary>
    Task<IEnumerable<Event>> ListAsync(DateTime? filter = null);

    /// <summary>
    /// Update an existing event
    /// </summary>
    Task<Event> UpdateAsync(Guid eventId, Event entity);

    /// <summary>
    /// Delete an existing event
    /// </summary>
    Task DeleteAsync(Guid eventId);
}

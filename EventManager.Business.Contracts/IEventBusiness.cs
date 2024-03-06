using EventManager.Models;

namespace EventManager.Business.Contracts;

public interface IEventBusiness
{
    Task<Event> CreateAsync(Event entity);
    Task<IEnumerable<Event>> ListAsync(DateTime? filter = null);
}

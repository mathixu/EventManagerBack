using EventManager.Models;

namespace EventManager.DAL.Contracts;

public interface IEventRepository
{
    Task<Event> InsertAsync(Event entity);
    Task<IEnumerable<Event>> ListAsync(DateTime? filter = null);
    Task<Event> UpdateAsync(Event entity);
    Task<Event?> FindAsync(Guid id);
}

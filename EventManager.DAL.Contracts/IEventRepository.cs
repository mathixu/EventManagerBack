using EventManager.Models;

namespace EventManager.DAL.Contracts;

public interface IEventRepository
{
    Task<Event> InsertAsync(Event entity);
}

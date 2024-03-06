using EventManager.DAL.Contracts;
using EventManager.Models;

namespace EventManager.DAL;

public class EventRepository : IEventRepository
{
    private readonly EventManagerDbContext _context;

    public EventRepository(EventManagerDbContext context)
    {
        _context = context;
    }

    public async Task<Event> InsertAsync(Event entity)
    {
        var result = await _context.Events.AddAsync(entity);

        await _context.SaveChangesAsync();
        
        return result.Entity;
    }
}

using EventManager.DAL.Contracts;
using EventManager.Models;
using Microsoft.EntityFrameworkCore;

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

    public async Task<IEnumerable<Event>> ListAsync(DateTime? filter = null)
    {
        if (filter.HasValue)
        {
            return await _context.Events.Where(e => e.Date.Date == filter.Value.Date).ToListAsync();
        }

        return await _context.Events.ToListAsync();
    }

    public async Task<Event> UpdateAsync(Event entity)
    {
        var result = _context.Events.Update(entity);

        await _context.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<Event?> FindAsync(Guid id)
    {
        return await _context.Events.FindAsync(id);
    }
}

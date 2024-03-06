using EventManager.Business.Contracts;
using EventManager.DAL.Contracts;
using EventManager.Models;

namespace EventManager.Business;

public class EventBusiness : IEventBusiness
{
    private readonly IEventRepository _eventRepository;

    public EventBusiness(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    /// <inheritdoc />
    public async Task<Event> CreateAsync(Event entity)
    {
        var validation = ValidateEvent(entity);

        if (!string.IsNullOrWhiteSpace(validation))
            throw new ArgumentException(validation);

        return await _eventRepository.InsertAsync(entity);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Event>> ListAsync(DateTime? filter = null)
    {
        return await _eventRepository.ListAsync(filter);
    }

    /// <inheritdoc />
    public async Task<Event> UpdateAsync(Guid eventId, Event entity)
    {
        var existing = await _eventRepository.FindAsync(eventId)
            ?? throw new ArgumentException("Event not found");
        
        var validation = ValidateEvent(entity);

        if (!string.IsNullOrWhiteSpace(validation))
            throw new ArgumentException(validation);

        existing.Title = entity.Title;
        existing.Description = entity.Description;
        existing.Date = entity.Date;
        existing.Location = entity.Location;
        
        return await _eventRepository.UpdateAsync(existing);
    }

    /// <inheritdoc />
    public async Task DeleteAsync(Guid eventId)
    {
        var existing = await _eventRepository.FindAsync(eventId)
            ?? throw new ArgumentException("Event not found");

        await _eventRepository.DeleteAsync(existing);
    }

    private static string ValidateEvent(Event entity)
    {
        if (entity is null)
            return "Event is required";

        if (string.IsNullOrWhiteSpace(entity.Title))
            return "Title is required";

        if (string.IsNullOrWhiteSpace(entity.Description))
            return "Description is required";

        if (entity.Date == default)
            return "Date is required";

        if (string.IsNullOrWhiteSpace(entity.Location))
            return "Location is required";

        return string.Empty;
    }
}

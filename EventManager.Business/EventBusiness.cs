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

    public async Task<Event> CreateAsync(Event entity)
    {
        if (entity is null)
            throw new ArgumentNullException(nameof(entity));

        if (string.IsNullOrWhiteSpace(entity.Title))
            throw new ArgumentException("Title is required", nameof(entity.Title));

        if (string.IsNullOrWhiteSpace(entity.Description))
            throw new ArgumentException("Description is required", nameof(entity.Description));

        if (entity.Date == default)
            throw new ArgumentException("Date is required", nameof(entity.Date));

        if (string.IsNullOrWhiteSpace(entity.Location))
            throw new ArgumentException("Location is required", nameof(entity.Location));

        return await _eventRepository.InsertAsync(entity);
    }

    public async Task<IEnumerable<Event>> ListAsync(DateTime? filter = null)
    {
        return await _eventRepository.ListAsync(filter);
    }
}

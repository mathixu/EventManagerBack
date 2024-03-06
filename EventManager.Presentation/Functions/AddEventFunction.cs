using EventManager.Business.Contracts;
using EventManager.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using EventManager.Presentation.Helpers;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.AspNetCore.Mvc;
using EventManager.Presentation.Models;

namespace EventManager.Presentation.Functions
{
    public class AddEventFunction
    {
        private readonly ILogger<AddEventFunction> _logger;
        private readonly IEventBusiness _eventBusiness;

        public AddEventFunction(ILogger<AddEventFunction> logger, IEventBusiness eventBusiness)
        {
            _logger = logger;
            _eventBusiness = eventBusiness;
        }

        [Function("AddEventFunction")]
        public async Task<IActionResult> AddEvent([HttpTrigger(AuthorizationLevel.Function, "post", Route = "event")] HttpRequestData req)
        {
            try
            {
                var dto = await req.GetBodyAsync<CreateEventDto>();

                if (dto is null)
                {
                    return new BadRequestObjectResult(new { error = "Invalid request body" });
                }

                var entity = new Event
                {
                    Title = dto.Title,
                    Description = dto.Description,
                    Date = dto.Date,
                    Location = dto.Location
                };

                var result = await _eventBusiness.CreateAsync(entity);

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new BadRequestObjectResult(new { error = ex.Message });
            }
        }
    }
}

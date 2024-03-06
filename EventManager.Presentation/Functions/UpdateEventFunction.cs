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
    public class UpdateEventFunction
    {
        private readonly ILogger<UpdateEventFunction> _logger;
        private readonly IEventBusiness _eventBusiness;

        public UpdateEventFunction(ILogger<UpdateEventFunction> logger, IEventBusiness eventBusiness)
        {
            _logger = logger;
            _eventBusiness = eventBusiness;
        }

        [Function("UpdateEventFunction")]
        public async Task<IActionResult> UpdateEvent([HttpTrigger(AuthorizationLevel.Function, "put", Route = "events/{eventId:guid}")] HttpRequestData req, Guid eventId)
        {
            try
            {
                var dto = await req.GetBodyAsync<UpdateEventDto>();

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

                var result = await _eventBusiness.UpdateAsync(eventId, entity);

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

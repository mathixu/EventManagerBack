using EventManager.Business.Contracts;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.AspNetCore.Mvc;
using EventManager.Presentation.Helpers;
using EventManager.Presentation.Models;

namespace EventManager.Presentation.Functions
{
    public class ListEventsFunction
    {
        private readonly ILogger<ListEventsFunction> _logger;
        private readonly IEventBusiness _eventBusiness;

        public ListEventsFunction(ILogger<ListEventsFunction> logger, IEventBusiness eventBusiness)
        {
            _logger = logger;
            _eventBusiness = eventBusiness;
        }

        [Function("ListEventsFunction")]
        public async Task<IActionResult> ListEvents([HttpTrigger(AuthorizationLevel.Function, "get", Route = "events")] HttpRequestData req)
        {
            try
            {
                var query = req.GetQuery<ListEventsFilterQuery>();

                var events = await _eventBusiness.ListAsync(query?.Date);

                return new OkObjectResult(events);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new BadRequestObjectResult(new { error = ex.Message });
            }
        }
    }
}

using EventManager.Business.Contracts;
using EventManager.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using EventManager.Presentation.Helpers;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.AspNetCore.Mvc;
using EventManager.Presentation.Models;
using Microsoft.Extensions.FileProviders;

namespace EventManager.Presentation.Functions
{
    public class DeleteEventFunction
    {
        private readonly ILogger<DeleteEventFunction> _logger;
        private readonly IEventBusiness _eventBusiness;

        public DeleteEventFunction(ILogger<DeleteEventFunction> logger, IEventBusiness eventBusiness)
        {
            _logger = logger;
            _eventBusiness = eventBusiness;
        }

        [Function("DeleteEventFunction")]
        public async Task<IActionResult> DeleteEvent([HttpTrigger(AuthorizationLevel.Function, "delete", Route = "events/{eventId:Guid}")] HttpRequestData req, Guid eventId)
        {
            try
            {
                await _eventBusiness.DeleteAsync(eventId);

                return new NoContentResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new BadRequestObjectResult(new { error = ex.Message });
            }
        }
    }
}

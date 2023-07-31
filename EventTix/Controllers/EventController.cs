using EventTix.Models;
using EventTix.Models.Dto;
using EventTix.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventTix.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class EventController : ControllerBase
    {
		private readonly IEventService _eventService;
        private readonly ILogger _logger;

        public EventController(IEventService eventService, ILogger<EventController> logger)
		{
            _eventService = eventService;
            _logger = logger;
		}

		[HttpGet]
		public ActionResult<List<EventDto>> GetAllEvents()
		{
            try
            {
                return Ok(_eventService.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }

		}

        [HttpGet]
        public async Task<ActionResult<EventDto>> GetEventById(int id)
        {
            var @event = await _eventService.GetById(id);
            return Ok(@event);

        }

        [HttpPatch]
        public async Task<ActionResult<Event>> Patch(EventPatchDto eventPatch)
        {
            if (eventPatch == null) throw new ArgumentNullException(nameof(eventPatch));
            var updatedEvent = await _eventService.Patch(eventPatch);
            if (updatedEvent == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<Event>> Delete(int id)
        {
            var deletedEvent = await _eventService.Delete(id);
            if (deletedEvent == null)
                return NotFound();

            return NoContent();
        }
    }
}


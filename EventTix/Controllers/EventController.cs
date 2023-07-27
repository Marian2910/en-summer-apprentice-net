using AutoMapper;
using EventTix.Models;
using EventTix.Models.Dto;
using EventTix.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EventTix.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class EventController : ControllerBase
    {
		private readonly IEventService _eventService;

        public EventController(IEventService eventService)
		{
            _eventService = eventService;
		}

		[HttpGet]
		public ActionResult<List<EventDto>> GetAllEvents()
		{
			return Ok(_eventService.GetAll());

		}

        [HttpGet]
        public async Task<ActionResult<EventDto>> GetEventById(int id)
        {
            var @event = await _eventService.GetById(id);
            if (@event == null)
            {
                return NotFound();
            }
            return Ok(@event);
        }

        [HttpPatch]
        public async Task<ActionResult<Event>> Patch(EventPatchDto eventPatch)
        {
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


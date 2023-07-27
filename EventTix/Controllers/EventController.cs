using AutoMapper;
using EventTix.Models;
using EventTix.Models.Dto;
using EventTix.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EventTix.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class EventController : ControllerBase
    {
		private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventController(IEventRepository eventRepository, IMapper mapper)
		{
            _eventRepository = eventRepository;
			_mapper = mapper;
		}

		[HttpGet]
		public ActionResult<List<EventDto>> getAllEvents()
		{
            var dtoEvents = _eventRepository.GetEvents().Select(_mapper.Map<EventDto>);
			return Ok(dtoEvents);

		}

		[HttpGet]
		public async Task<ActionResult<EventDto>> getById(int id)
		{
			var @event = await _eventRepository.GetEventById(id);
			if(@event == null )
			{
				return NotFound();
			}

			var eventDto = _mapper.Map<EventDto>(@event);
            return Ok(eventDto);
		}
		[HttpPatch]
		public async Task<ActionResult<EventPatchDto>> Patch(EventPatchDto eventPatch)
		{
			var eventEntity = await _eventRepository.GetEventById(eventPatch.EventId);
			if (eventEntity == null)
			{
				return NotFound();
			}

            if (!eventPatch.EventName.IsNullOrEmpty()) eventEntity.EventName = eventPatch.EventName;
            if (!eventPatch.EventDescription.IsNullOrEmpty()) eventEntity.EventDescription = eventPatch.EventDescription;
            _eventRepository.Update(eventEntity);
			return NoContent();

		}
		[HttpDelete]
		public async Task<ActionResult> Delete(int id)
		{
            var eventEntity = await _eventRepository.GetEventById(id);
            if (eventEntity == null)
            {
                return NotFound();
            }
			_eventRepository.Delete(eventEntity);
			return NoContent();
        }
	}
}


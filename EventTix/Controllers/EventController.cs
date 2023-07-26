using AutoMapper;
using EventTix.Models;
using EventTix.Models.Dto;
using EventTix.Repositories;
using Microsoft.AspNetCore.Mvc;

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
		public ActionResult<EventDto> getById(int id)
		{
			var @event = _eventRepository.GetEventById(id);
			if(@event == null )
			{
				return NotFound();
			}

			var eventDto = _mapper.Map<EventDto>(@event);
            return Ok(eventDto);
		}
	}
}


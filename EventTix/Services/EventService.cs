using System;
using AutoMapper;
using EventTix.Models;
using EventTix.Models.Dto;
using EventTix.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace EventTix.Services
{
	public class EventService : IEventService
	{
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventService(IEventRepository eventRepository, IMapper mapper)
		{
            _eventRepository = eventRepository;
            _mapper = mapper;

        }

        public List<EventDto> GetAll()
        {
            return _eventRepository.GetEvents().Select(_mapper.Map<EventDto>).ToList();

        }

        public async Task<EventDto> GetById(int id)
        {
            var @event = await _eventRepository.GetEventById(id);
            var eventDto = _mapper.Map<EventDto>(@event);

            return eventDto;
        }

        public async Task<Event> Patch(EventPatchDto eventPatch)
        {
            var eventEntity = await _eventRepository.GetEventById(eventPatch.EventId);

            if (!eventPatch.EventName.IsNullOrEmpty()) eventEntity.EventName = eventPatch.EventName;
            if (!eventPatch.EventDescription.IsNullOrEmpty()) eventEntity.EventDescription = eventPatch.EventDescription;
            _eventRepository.Update(eventEntity);
            var updatedEvent = await _eventRepository.GetEventById(eventPatch.EventId);

            return updatedEvent;
        }

        public async Task<Event> Delete(int id)
        {
            var eventEntity = await _eventRepository.GetEventById(id);
            _eventRepository.Delete(eventEntity);
            return eventEntity;
        }

    }
}

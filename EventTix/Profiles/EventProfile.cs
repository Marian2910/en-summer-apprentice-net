using System;
using AutoMapper;
using EventTix.Models;
using EventTix.Models.Dto;

namespace EventTix.Profiles
{
	public class EventProfile : Profile
	{
		public EventProfile()
		{
            CreateMap<Event, EventDto>()
           .ForMember(dest => dest.EventType, opt => opt.MapFrom(src => src.EventType.EventTypeName))
           .ForMember(dest => dest.Venue, opt => opt.MapFrom(src => src.Venue.Location)).ReverseMap();
            CreateMap<Event, EventPatchDto>().ReverseMap();

        }
    }
}


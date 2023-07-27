using System;
using AutoMapper;
using EventTix.Models;
using EventTix.Models.Dto;

namespace EventTix.Profiles
{
	public class OrderProfile : Profile
	{
		public OrderProfile()
		{
            CreateMap<Order, OrderDto>()
          .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.CustomerName))
          .ForMember(dest => dest.TicketCategory, opt => opt.MapFrom(src => src.TicketCategory.Description))
          .ForMember(dest => dest.EventName, opt => opt.MapFrom(src => src.TicketCategory.Event.EventName)).ReverseMap();
            CreateMap<Order, OrderPatchDto>().ReverseMap();
        }
    }
}

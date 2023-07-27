﻿using System;
using AutoMapper;
using EventTix.Models;
using EventTix.Models.Dto;
using EventTix.Repositories;

namespace EventTix.Services
{
	public interface IEventService
	{
        public List<EventDto> GetAll();

        public Task<EventDto> GetById(int id);

        public Task<Event> Patch(EventPatchDto eventPatch);

        public Task<Event> Delete(int id);

    }
}


﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LPBusiness.Domain;
using LPBusiness.Domain.Attachment_Area;
using LPBusiness.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace LPBusiness.Repository.EF.Repositories
{
    public sealed class EventRepository : IEventRepository
    {
        public Task CreateEventAsync(Event @event)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Event>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Event>> GetFromTimeAsync(DateTime searchDateFromUtc)
        {
            using (LPBusinessContext context = new LPBusinessContext())
            {
                return (await context.Events.Where(ev => ev.DateTime >= searchDateFromUtc).ToListAsync()).
                    Select(ev=> Event.Create(ev.Id, ev.DateTime, new List<Attachment>()));
            }
        }
    }
}

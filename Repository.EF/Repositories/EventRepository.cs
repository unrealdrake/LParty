using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Attachment_Area;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Repository.EF.Repositories
{
    public sealed class EventRepository : IEventRepository
    {
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

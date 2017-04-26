using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Repository;

namespace RepositoryLPBusiness.InMemory.Repositories
{
    public class EventRepository : IEventRepository
    {
        private static IEnumerable<Event> _events = new List<Event>();

        public static void FillEvents(IEnumerable<Event> events)
        {
            _events = events;
        }

        public async Task<IEnumerable<Event>> GetFromTimeAsync(DateTime searchDateFromUtc)
        {
            return await Task.Run(() => _events.Where(ev => ev.DateTime >= searchDateFromUtc).ToList());
        }
    }
}

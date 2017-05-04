using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.LBPusiness.Repository;
using Core.LPBusiness.Domain;
using Shared.Infrasctructure.BusinessTransaction;

namespace Repository.LPBusiness.InMemory.Repositories
{
    public class EventRepository : IEventRepository
    {
        private static IList<Event> _events = new List<Event>();

        public static void FillEvents(IList<Event> events)
        {
            _events = events;
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            return await Task.Run(() => _events);
        }

        public async Task<IEnumerable<Event>> GetFromTimeAsync(DateTime searchDateFromUtc)
        {
            return await Task.Run(() => _events.Where(ev => ev.DateTime >= searchDateFromUtc).ToList());
        }

        public async Task CreateEventAsync(Event @event)
        {
            using (CommitableBusinessTransaction businessTransaction = new CommitableBusinessTransaction())
            {
                TransactionCompleteHandler transactionHandler = new TransactionCompleteHandler(businessTransaction);

                await Task.Run(() => _events.Add(@event));
                transactionHandler.Aborted += () => { _events.Remove(@event); };

                businessTransaction.Commit();
            }
        }
    }
}


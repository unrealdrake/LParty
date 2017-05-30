using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LPBusiness.Domain.Repository
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetFromTimeAsync(DateTime searchDateFromUtc);
        Task<IEnumerable<Event>> GetAllAsync();
        Task CreateEventAsync(Event @event);
    }
}

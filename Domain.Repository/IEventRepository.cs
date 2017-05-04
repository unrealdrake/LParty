using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.LPBusiness.Domain;

namespace Core.LBPusiness.Repository
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetFromTimeAsync(DateTime searchDateFromUtc);
        Task<IEnumerable<Event>> GetAllAsync();
        Task CreateEventAsync(Event @event);
    }
}

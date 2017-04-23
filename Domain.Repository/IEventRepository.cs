using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetFromTimeAsync(DateTime searchDateFromUtc);
    }
}

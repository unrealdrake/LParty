using LPBusiness.Repository.EF.DataModel;
using Microsoft.EntityFrameworkCore;

namespace LPBusiness.Repository.EF.FluentConfiguration
{
    internal sealed class EventMap
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().HasKey(ev => ev.Id);
        }
    }
}

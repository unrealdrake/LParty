using Microsoft.EntityFrameworkCore;
using Repository.EF.DataModel;

namespace Repository.EF.FluentConfiguration
{
    internal sealed class EventMap
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().HasKey(ev => ev.Id);
        }
    }
}

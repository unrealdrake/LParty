using Microsoft.EntityFrameworkCore;
using Repository.LPBusiness.EF.DataModel;

namespace Repository.LPBusiness.EF.FluentConfiguration
{
    internal sealed class EventMap
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().HasKey(ev => ev.Id);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using RepositoryLPBusiness.EF.DataModel;

namespace RepositoryLPBusiness.EF.FluentConfiguration
{
    internal sealed class EventMap
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().HasKey(ev => ev.Id);
        }
    }
}

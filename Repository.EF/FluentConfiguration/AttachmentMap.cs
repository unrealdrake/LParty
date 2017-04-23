
using Microsoft.EntityFrameworkCore;
using Repository.EF.DataModel;

namespace Repository.EF.FluentConfiguration
{
    internal class AttachmentMap
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attachment>().HasKey(ev => ev.Id);
        }
    }
}

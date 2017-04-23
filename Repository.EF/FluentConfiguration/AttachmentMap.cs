using Microsoft.EntityFrameworkCore;
using Repository.LPBusiness.EF.DataModel;

namespace Repository.LPBusiness.EF.FluentConfiguration
{
    internal class AttachmentMap
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attachment>().HasKey(ev => ev.Id);
        }
    }
}

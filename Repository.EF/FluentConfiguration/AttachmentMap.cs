using LPBusiness.Repository.EF.DataModel;
using Microsoft.EntityFrameworkCore;

namespace LPBusiness.Repository.EF.FluentConfiguration
{
    internal class AttachmentMap
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attachment>().HasKey(ev => ev.Id);
        }
    }
}

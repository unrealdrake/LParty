using Microsoft.EntityFrameworkCore;
using RepositoryLPBusiness.EF.DataModel;

namespace RepositoryLPBusiness.EF.FluentConfiguration
{
    internal class AttachmentMap
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attachment>().HasKey(ev => ev.Id);
        }
    }
}

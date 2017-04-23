using Microsoft.EntityFrameworkCore;
using Repository.LPBusiness.EF.DataModel;
using Repository.LPBusiness.EF.FluentConfiguration;
using Shared.Config;

namespace Repository.LPBusiness.EF
{
    public sealed class LPBusinessContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.ConnectionString_LP);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EventMap.Configure(modelBuilder);
            AttachmentMap.Configure(modelBuilder);
        }
    }
}

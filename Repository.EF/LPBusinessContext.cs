using LPBusiness.Repository.EF.DataModel;
using LPBusiness.Repository.EF.FluentConfiguration;
using Microsoft.EntityFrameworkCore;
using Shared.Config;

namespace LPBusiness.Repository.EF
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

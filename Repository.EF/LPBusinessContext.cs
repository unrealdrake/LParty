using Microsoft.EntityFrameworkCore;
using RepositoryLPBusiness.EF.DataModel;
using RepositoryLPBusiness.EF.FluentConfiguration;
using Shared.Config;

namespace RepositoryLPBusiness.EF
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

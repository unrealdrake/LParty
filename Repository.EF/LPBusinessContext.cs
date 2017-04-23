using Domain;
using Microsoft.EntityFrameworkCore;
using Repository.EF.FluentConfiguration;
using Shared.Config;

namespace Repository.EF
{
    public sealed class LPBusinessContext : DbContext
    {
        public DbSet<DataModel.Event> Events { get; set; }
        public DbSet<DataModel.Attachment> Attachments { get; set; }

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

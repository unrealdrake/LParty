using LP.UserProfile.Domain.User_Area;
using LP.UserProfile.EFRepository.FluentMappings;
using Microsoft.EntityFrameworkCore;
using Shared.Config;
using Shared.Infrasctructure.EntityFramework;

namespace LP.UserProfile.EFRepository
{
    public sealed class UserProfileEFContext : DbContext
    {
        public DbSet<User> UserProfiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.ConnectionString_LP);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.AddConfiguration(new UserConfiguration());
            modelBuilder.AddConfiguration(new AddressConfiguration());
        }
    }
}

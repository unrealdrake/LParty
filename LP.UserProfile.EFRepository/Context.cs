using LP.UserProfile.Domain.User_Area;
using Microsoft.EntityFrameworkCore;
using Shared.Config;

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

            new UserMap(modelBuilder.Entity<User>());
        }
    }
}

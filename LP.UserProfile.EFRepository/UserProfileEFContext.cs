using System;
using LP.UserProfile.Domain.User_Area.Core;
using LP.UserProfile.Domain.User_Area.Core.Specifications;
using LP.UserProfile.EFRepository.FluentMappings;
using LP.UserProfile.EFRepository.SpecificationOverridings;
using Microsoft.EntityFrameworkCore;
using Shared.Infrasctructure.EntityFramework;

namespace LP.UserProfile.EFRepository
{
    public class UserProfileEFContext : DbContext
    {
        public DbSet<User> UserProfiles { get; set; }
        private string ConnectionString { get; }

        static UserProfileEFContext()
        {
            SpecificationOverridingBuilder.RegisterOverriding(typeof(UserExistsByLoginSpec), typeof(UserExistsByLoginSpec_EF));
        }

        public UserProfileEFContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.AddConfiguration(new UserConfiguration());
            modelBuilder.AddConfiguration(new AddressConfiguration());
        }
    }
}

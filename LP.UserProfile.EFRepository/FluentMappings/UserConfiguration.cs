using LP.UserProfile.Domain.User_Area;
using LP.UserProfile.Domain.User_Area.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Infrasctructure.EntityFramework;

namespace LP.UserProfile.EFRepository.FluentMappings
{
    public class UserConfiguration : DbEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User").HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            builder.HasOne(user => user.Address).WithOne(a => a.User).HasForeignKey<Address>(a => a.UserId).OnDelete(DeleteBehavior.Cascade);
            //PersonalInformation
            builder.OwnsOne(user => user.PersonalInformation).Property(pi => pi.FirstName).HasColumnName("FirstName");
            builder.OwnsOne(user => user.PersonalInformation).Property(pi => pi.LastName).HasColumnName("LastName");
            //LoginData
            builder.OwnsOne(user => user.LoginData).Property(pi => pi.Login).HasColumnName("Login");
        }
    }
}

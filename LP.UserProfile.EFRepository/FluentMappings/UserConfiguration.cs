using LP.UserProfile.Domain.User_Area;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Infrasctructure.EntityFramework;

namespace LP.UserProfile.EFRepository.FluentMappings
{
    public class UserConfiguration : DbEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(u => u.Id);
            builder.OwnsOne(user => user.PersonalInformation);
            builder.HasOne(user => user.Address).WithOne(a => a.User).HasForeignKey<Address>(a => a.UserId);
        }
    }
}

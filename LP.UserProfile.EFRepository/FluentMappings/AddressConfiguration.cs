using LP.UserProfile.Domain.User_Area.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Infrasctructure.EntityFramework;

namespace LP.UserProfile.EFRepository.FluentMappings
{
    public class AddressConfiguration : DbEntityConfiguration<Address>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address").HasKey("Id");
            builder.Property("Id").ValueGeneratedOnAdd();
        }
    }
}

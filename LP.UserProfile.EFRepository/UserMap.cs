using LP.UserProfile.Domain.User_Area;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LP.UserProfile.EFRepository
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(u => u.Id);

            entityBuilder.OwnsOne(u => u.PersonalInformation);
        }
    }
}

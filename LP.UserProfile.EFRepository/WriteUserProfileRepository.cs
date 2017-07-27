using LP.UserProfile.Repository;
using LP.UserProfile.Domain.User_Area;
using Shared.Infrasctructure.EntityFramework;

namespace LP.UserProfile.EFRepository
{
    public class WriteUserProfileRepository : BaseWriteEFRepository<User>, IWriteUserProfileRepository
    {
        private readonly UserProfileEFContext _efContext;

        public WriteUserProfileRepository(UserProfileEFContext efContext) : base(efContext)
        {
            _efContext = efContext;
        }

        public void AddNewProfile(User userProfile)
        {
            Add(userProfile);
        }
    }
}

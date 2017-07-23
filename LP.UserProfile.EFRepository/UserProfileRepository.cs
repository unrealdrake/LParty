using System.Collections.ObjectModel;
using System.Linq;
using LP.UserProfile.Repository;
using LP.UserProfile.Domain.User_Area;
using Microsoft.EntityFrameworkCore;
using Shared.Infrasctructure.EntityFramework;

namespace LP.UserProfile.EFRepository
{
    public class UserProfileRepository : BaseEFRepository, IUserProfileRepository
    {
        private readonly UserProfileEFContext _efContext;

        public UserProfileRepository(UserProfileEFContext efContext) : base(efContext)
        {
            _efContext = efContext;
        }

        public ReadOnlyCollection<User> GetAllUsers()
        {
            return _efContext.UserProfiles.AsNoTracking().ToList().AsReadOnly();
        }

        public void ClearAll()
        {
            _efContext.UserProfiles.Clear();
            _efContext.SaveChanges();
        }

        public void AddNewProfile(User userProfile)
        {
            _efContext.UserProfiles.Add(userProfile);
            _efContext.SaveChanges();
        }
    }
}

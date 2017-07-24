using System.Collections.ObjectModel;
using System.Linq;
using LP.UserProfile.Repository;
using LP.UserProfile.Domain.User_Area;
using Microsoft.EntityFrameworkCore;
using Shared.Infrasctructure.EntityFramework;

namespace LP.UserProfile.EFRepository
{
    public class ReadUserProfileRepository : BaseEFRepository, IReadUserProfileRepository
    {
        private readonly UserProfileEFContext _efContext;

        public ReadUserProfileRepository(UserProfileEFContext efContext) : base(efContext)
        {
            _efContext = efContext;
        }

        public ReadOnlyCollection<User> GetAllUsers()
        {
            return _efContext.UserProfiles.AsNoTracking().ToList().AsReadOnly();
        }
    }
}

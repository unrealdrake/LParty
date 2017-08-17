using System.Linq;
using LP.UserProfile.Domain.User_Area.Core;
using LP.UserProfile.Domain.User_Area.Repositories;
using Microsoft.EntityFrameworkCore;
using Shared.Infrasctructure.EntityFramework;

namespace LP.UserProfile.EFRepository
{
    public class WriteUserProfileRepository : BaseWriteEFRepository<User>, IWriteUserProfileRepository
    {
        public WriteUserProfileRepository(UserProfileEFContext efContext) : base(efContext)
        {
        }

        public void AddNewProfile(User userProfile)
        {
            Add(userProfile);
        }

        public void ClearAll()
        {
            foreach (var userProfile in Context.Set<User>().
                Include(u => u.PersonalInformation).
                Include(u => u.LoginData).
                ToList())
            {
                Delete(userProfile);
            }
        }

        public void Delete(User userProfile)
        {
            Context.Attach(userProfile);
            Context.Remove(userProfile.PersonalInformation);
            Context.Remove(userProfile.LoginData);
            Context.Remove(userProfile);
            Context.SaveChanges();
        }
    }
}

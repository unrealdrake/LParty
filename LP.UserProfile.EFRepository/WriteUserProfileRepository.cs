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
            foreach (var userProfile in Context.Set<User>().ToList())
            {
                Delete(userProfile.Id);
            }
        }

        public void Delete(int userProfileId)
        {
            var user = Context.Set<User>()
                .Include(u => u.Address)
                .Include(u => u.LoginData)
                .Include(u => u.PersonalInformation).FirstOrDefault(u => u.Id == userProfileId);
            Context.Entry(user).State = EntityState.Deleted;
            Context.Entry(user.LoginData).State = EntityState.Deleted;
            Context.Entry(user.Address).State = EntityState.Deleted;
            Context.Entry(user.PersonalInformation).State = EntityState.Deleted;
            Context.SaveChanges();
        }
    }
}

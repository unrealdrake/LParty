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

        public void Delete(User entity)
        {
            Context.Attach(entity);
            Context.Entry(entity).State = EntityState.Deleted;
            Context.Entry(entity.Address).State = EntityState.Deleted;
            Context.Entry(entity.LoginData).State = EntityState.Deleted;
            Context.Entry(entity.PersonalInformation).State = EntityState.Deleted;
            Context.SaveChanges();
        }

        public void AddNewProfile(User userProfile)
        {
            Add(userProfile);
        }   

        public void ClearAll()
        {
            foreach (var userProfile in Context.Set<User>()
                .Include(up => up.LoginData)
                .Include(up => up.PersonalInformation)
                .Include(up => up.Address).ToList())
            {
                Delete(userProfile);
            }
        }
    }
}

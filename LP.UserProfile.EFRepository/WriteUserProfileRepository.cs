using System.Linq;
using System.Threading.Tasks;
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

        public async Task AddNewProfileAsync(User userProfile)
        {
            await AddAsync(userProfile);
        }

        public async Task ClearAllAsync()
        {
            foreach (var userProfile in Context.Set<User>().
                Include(u => u.PersonalInformation).
                Include(u => u.LoginData).
                ToList())
            {
                await DeleteAsync(userProfile);
            }
        }

        public async Task DeleteAsync(User userProfile)
        {
            Context.Attach(userProfile);
            Context.Remove(userProfile.PersonalInformation);
            Context.Remove(userProfile.LoginData);
            Context.Remove(userProfile);
            await Context.SaveChangesAsync();
        }
    }
}

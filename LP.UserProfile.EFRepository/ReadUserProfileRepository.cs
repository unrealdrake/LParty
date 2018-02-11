using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using LP.UserProfile.Domain.User_Area.Core;
using LP.UserProfile.Domain.User_Area.Repositories;
using Microsoft.EntityFrameworkCore;
using Shared.Infrasctructure.EntityFramework;

namespace LP.UserProfile.EFRepository
{
    public class ReadUserProfileRepository : BaseReadEFRepository<User>, IReadUserProfileRepository
    {
        private readonly UserProfileEFContext _efContext;

        public ReadUserProfileRepository(UserProfileEFContext efContext) : base(efContext)
        {
            _efContext = efContext;
        }

        public async Task<ReadOnlyCollection<User>> GetAllUsersAsync()
        {
            return (await _efContext.UserProfiles
                        //.Include(up => up.LoginData)
                        //.Include(up => up.PersonalInformation)
                        .Include(up => up.Address).
                        AsNoTracking().ToListAsync()).AsReadOnly();
        }
    }
}

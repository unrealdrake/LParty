using System.Collections.ObjectModel;
using System.Linq;
using LP.UserProfile.Domain.User_Area;
using SharedKernel.Repository;

namespace LP.UserProfile.EFRepository
{
    public class UsersRepository : BaseRepository<User>
    {
        private readonly UserProfileEFContext _context;
        public UsersRepository(UserProfileEFContext efContext)
        {
            _context = efContext;
        }

        public ReadOnlyCollection<User> GetUsers()
        {
            return _context.UserProfiles.ToList().AsReadOnly();
        }
    }
}

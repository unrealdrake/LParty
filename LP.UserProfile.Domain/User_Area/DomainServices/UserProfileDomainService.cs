using System.Linq;
using System.Threading.Tasks;
using LP.UserProfile.Domain.User_Area.Core;
using LP.UserProfile.Domain.User_Area.Core.Specifications;
using LP.UserProfile.Domain.User_Area.Events;
using LP.UserProfile.Domain.User_Area.Repositories;
using Shared.Infrasctructure.ObjectExtensions;
using SharedKernel.DomainEvents;

namespace LP.UserProfile.Domain.User_Area.DomainServices
{
    public sealed class UserProfileDomainService
    {
        private readonly IReadUserProfileRepository _readUserProfileRepository;
        private readonly IWriteUserProfileRepository _writeUserProfileRepository;

        public UserProfileDomainService(IReadUserProfileRepository readUserProfileRepository, IWriteUserProfileRepository writeUserProfileRepository)
        {
            _readUserProfileRepository = readUserProfileRepository;
            _writeUserProfileRepository = writeUserProfileRepository;
        }

        public async Task<bool> IsAlreadyExistAsync(string login)
        {
            login.NotNullOrEmpty();

            return (await _readUserProfileRepository.FindAsync(new UserExistsByLoginSpec(login))).Any();
        }

        public async Task<bool> RegisterNewProfileAsync(User userProfile)
        {
            userProfile.NotNull();

            if (! await IsAlreadyExistAsync(userProfile.LoginData.Login))
            {
                await _writeUserProfileRepository.AddNewProfileAsync(userProfile);
                DomainEvents.Raise(new UserProfileCreatedEvent(userProfile.Id));
                
                return true;
            }

            return false;
        }
    }
}

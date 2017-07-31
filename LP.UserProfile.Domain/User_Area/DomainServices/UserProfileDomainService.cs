using System.Linq;
using LP.UserProfile.Domain.User_Area.Core;
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
            this._readUserProfileRepository = readUserProfileRepository;
            _writeUserProfileRepository = writeUserProfileRepository;
        }

        public bool IsAlreadyExist(string login)
        {
            login.NotNullOrEmpty();

            return _readUserProfileRepository.GetAllUsers().Any(user => user.LoginData.Login == login);
        }

        public bool RegisterNewProfile(User userProfile)
        {
            userProfile.NotNull();

            if (!IsAlreadyExist(userProfile.LoginData.Login))
            {
                _writeUserProfileRepository.AddNewProfile(userProfile);
                DomainEvents.Raise(new UserProfileCreatedEvent(userProfile.Id));
                
                return true;
            }

            return false;
        }
    }
}

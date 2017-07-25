using System.Linq;
using LP.UserProfile.Repository;
using Shared.Infrasctructure.ObjectExtensions;

namespace LP.UserProfile.DomainService
{
    public sealed class UserProfileDomainService
    {
        private readonly IReadUserProfileRepository _readUserProfileRepository;

        public UserProfileDomainService(IReadUserProfileRepository readUserProfileRepository)
        {
            this._readUserProfileRepository = readUserProfileRepository;
        }

        public bool IsAlreadyExist(string login)
        {
            login.NotNullOrEmpty();

            return _readUserProfileRepository.GetAllUsers().Any(user => user.LoginData.Login == login);
        }
    }
}

using System.Linq;
using LP.UserProfile.Domain.User_Area.Repositories;
using Shared.Infrasctructure.ObjectExtensions;

namespace LP.UserProfile.Domain.User_Area.DomainServices
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

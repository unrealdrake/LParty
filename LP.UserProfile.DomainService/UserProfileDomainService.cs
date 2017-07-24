using System;
using System.Linq;
using LP.UserProfile.Repository;

namespace LP.UserProfile.DomainService
{
    public sealed class UserProfileDomainService
    {
        private readonly IReadUserProfileRepository _readUserProfileRepository;

        public UserProfileDomainService(IReadUserProfileRepository readUserProfileRepository)
        {
            this._readUserProfileRepository = readUserProfileRepository;
        }

        public bool IsAlreadyExists(string login)
        {
            if (string.IsNullOrWhiteSpace(login)) { throw new ArgumentException(nameof(login));}

            return _readUserProfileRepository.GetAllUsers().Any(user => user.LoginData.Login == login);
        }
    }
}

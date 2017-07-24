using System;
using LP.UserProfile.Repository;
using MediatR;
using LP.UserProfile.DomainService;

namespace LP.UserProfile.ApplicationService.Write
{
    public class RegisterNewProfileHandler : IRequestHandler<RegisterNewProfileCommand, bool>
    {
        private readonly IWriteUserProfileRepository _writeUserProfileRepository;
        private readonly UserProfileDomainService _userProfileDomainService;

        public RegisterNewProfileHandler(IWriteUserProfileRepository writeUserProfileRepository, UserProfileDomainService userProfileDomainService)
        {
            _writeUserProfileRepository = writeUserProfileRepository;
            _userProfileDomainService = userProfileDomainService;
        }

        public bool Handle(RegisterNewProfileCommand message)
        {
            if (!_userProfileDomainService.IsAlreadyExists(message.UserProfile.LoginData.Login))
            {
                _writeUserProfileRepository.AddNewProfile(message.UserProfile);
                return true;
            }

            return false;
        }
    }
}

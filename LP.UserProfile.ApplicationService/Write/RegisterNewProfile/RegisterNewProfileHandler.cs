using LP.UserProfile.Domain.User_Area.DomainServices;
using LP.UserProfile.Domain.User_Area.Repositories;
using MediatR;

namespace LP.UserProfile.ApplicationService.Write.RegisterNewProfile
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
            if (!_userProfileDomainService.IsAlreadyExist(message.UserProfile.LoginData.Login))
            {
                _writeUserProfileRepository.AddNewProfile(message.UserProfile);
                return true;
            }

            return false;
        }
    }
}

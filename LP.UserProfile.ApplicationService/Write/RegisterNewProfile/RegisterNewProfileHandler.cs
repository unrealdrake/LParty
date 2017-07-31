using LP.UserProfile.Domain.User_Area.DomainServices;
using MediatR;

namespace LP.UserProfile.ApplicationService.Write.RegisterNewProfile
{
    public class RegisterNewProfileHandler : IRequestHandler<RegisterNewProfileCommand, bool>
    {
        private readonly UserProfileDomainService _userProfileDomainService;

        public RegisterNewProfileHandler(UserProfileDomainService userProfileDomainService)
        {
            _userProfileDomainService = userProfileDomainService;
        }

        public bool Handle(RegisterNewProfileCommand message)
        {
            return _userProfileDomainService.RegisterNewProfile(message.UserProfile);
        }
    }
}

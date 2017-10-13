using LP.UserProfile.Domain.User_Area.Core;
using LP.UserProfile.Domain.User_Area.DomainServices;
using MediatR;
using Shared.Infrasctructure.ObjectExtensions;

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
            message.NotNull();
            Address address = Address.Factory.Create(message.UserProfile.AddressCity);
            LoginData loginData = LoginData.Factory.Create(message.UserProfile.Login, message.UserProfile.Password);
            PersonalInformation personalInformation = PersonalInformation.Factory.Create(message.UserProfile.FirstName, message.UserProfile.LastName);
            User user = User.Factory.Create(personalInformation, address, loginData);

            return _userProfileDomainService.RegisterNewProfile(user);
        }
    }
}

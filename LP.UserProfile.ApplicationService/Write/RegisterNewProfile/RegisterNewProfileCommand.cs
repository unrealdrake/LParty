using LP.UserProfile.Gateway.Models;
using MediatR;
using Shared.Infrasctructure.ObjectExtensions;

namespace LP.UserProfile.ApplicationService.Write.RegisterNewProfile
{
    public sealed class RegisterNewProfileCommand: IRequest<bool>
    {
        public RegisterNewProfileDto UserProfile { get;}
        public RegisterNewProfileCommand(RegisterNewProfileDto userProfile)
        {
            userProfile.NotNull();
            UserProfile = userProfile;
        }
    }
}

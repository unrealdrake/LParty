using LP.UserProfile.Domain.User_Area;
using MediatR;
using Shared.Infrasctructure.ObjectExtensions;

namespace LP.UserProfile.ApplicationService.Write.RegisterNewProfile
{
    public sealed class RegisterNewProfileCommand: IRequest<bool>
    {
        public User UserProfile { get;}
        public RegisterNewProfileCommand(User userProfile)
        {
            userProfile.NotNull();
            UserProfile = userProfile;
        }
    }
}

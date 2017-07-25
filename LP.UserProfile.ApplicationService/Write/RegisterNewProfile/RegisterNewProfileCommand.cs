using System;
using LP.UserProfile.Domain.User_Area;
using MediatR;

namespace LP.UserProfile.ApplicationService.Write.RegisterNewProfile
{
    public sealed class RegisterNewProfileCommand: IRequest<bool>
    {
        public User UserProfile { get;}
        public RegisterNewProfileCommand(User userProfile)
        {
            UserProfile = userProfile ?? throw new ArgumentException(nameof(userProfile));
        }
    }
}

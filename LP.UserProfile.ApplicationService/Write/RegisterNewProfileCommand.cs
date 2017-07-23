
using LP.UserProfile.Domain.User_Area;
using MediatR;

namespace LP.UserProfile.ApplicationService.Write
{
    public sealed class RegisterNewProfileCommand: IRequest<bool>
    {
        public User UserProfile { get; set; }
    }
}

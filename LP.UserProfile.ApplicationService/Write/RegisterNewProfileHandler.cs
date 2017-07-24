using System;
using MediatR;

namespace LP.UserProfile.ApplicationService.Write
{
    public class RegisterNewProfileHandler : IRequestHandler<RegisterNewProfileCommand, bool>
    {
        public RegisterNewProfileHandler()
        {
            
        }
        public bool Handle(RegisterNewProfileCommand message)
        {
            throw new NotImplementedException();
        }
    }
}

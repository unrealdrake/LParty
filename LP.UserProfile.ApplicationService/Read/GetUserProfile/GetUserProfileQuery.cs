using System;
using MediatR;
using Shared.Infrasctructure.RequestResponse;

namespace LP.UserProfile.ApplicationService.Read.GetUserProfile
{
    public sealed class GetUserProfileQuery : IRequest<BaseResponse<GetUserProfileResponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public GetUserProfileQuery(string email, string password)
        {
            Email = email ?? throw new ArgumentException(nameof(email));
            Password = password ?? throw new ArgumentException(nameof(password));
        }
    }
}

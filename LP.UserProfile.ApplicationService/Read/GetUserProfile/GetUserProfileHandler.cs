using System.Threading.Tasks;
using LP.UserProfile.Domain.User_Area.Core;
using LP.UserProfile.Domain.User_Area.Core.Specifications;
using LP.UserProfile.Domain.User_Area.Repositories;
using MediatR;
using Shared.Infrasctructure.Errors;
using Shared.Infrasctructure.ObjectExtensions;
using Shared.Infrasctructure.RequestResponse;

namespace LP.UserProfile.ApplicationService.Read.GetUserProfile
{
    public class GetUserProfileHandler : IAsyncRequestHandler<GetUserProfileQuery, BaseResponse<GetUserProfileResponse>>
    {
        private readonly IReadUserProfileRepository _userProfileRepository;

        public GetUserProfileHandler(IReadUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<BaseResponse<GetUserProfileResponse>> Handle(GetUserProfileQuery query)
        {
            query.NotNull();

            var response = new BaseResponse<GetUserProfileResponse>();
            User userProfile = await _userProfileRepository.FindFirstOrDefaultAsync(new UserByEmailAndPasswordSpec(query.Email, query.Password));
            if (userProfile == null)
            {
                response.Exceptions.Add(ErrorsEnum.NotFound);
                return response;
            }

            response.Value = new GetUserProfileResponse(
                userProfile.Id,
                userProfile.PersonalInformation.FirstName,
                userProfile.PersonalInformation.LastName);

            return response;
        }
    }
}

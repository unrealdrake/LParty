using System.Threading.Tasks;
using LP.UserProfile.ApplicationService.Read.GetUserProfile;
using LP.UserProfile.ApplicationService.Write.RegisterNewProfile;
using LP.UserProfile.Domain.User_Area.DomainServices;
using LP.UserProfile.Gateway.Dto;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Shared.Gateway.Infrastructure;
using Shared.Infrasctructure.RequestResponse;

namespace LP.UserProfile.Api.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// User profiles working area
    /// </summary>
    [Route("api/[controller]")]
    public class UserProfilesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserProfileDomainService _userProfileDomainService;

        /// <inheritdoc />
        public UserProfilesController(IMediator mediatr, UserProfileDomainService userProfileDomainService)
        {
            _mediator = mediatr;
            _userProfileDomainService = userProfileDomainService;
        }

        /// <summary>
        /// Registers a new profile 
        /// </summary>
        /// <param name="registerProfileModel">Profile data</param>
        /// <returns>Is user profile was created successfully</returns>
        /// <response code="400">Invalid input data</response>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseError), 400)]
        public async Task<bool> Post([FromBody]RegisterNewProfileDto registerProfileModel)
        {
            return await _mediator.Send(new RegisterNewProfileCommand(registerProfileModel));
        }


        /// <summary>
        /// Gets profile 
        /// </summary>
        /// <param name="login">Login</param>
        /// <param name="password">Password</param>
        /// <returns>Is user profile was created successfully</returns>
        /// <response code="400">Invalid input data</response>
        [HttpGet]
        [ProducesResponseType(typeof(ResponseError), 400)]
        public async Task<GetUserProfileDto> Get(string login, string password)
        {
            BaseResponse<GetUserProfileResponse> userProfile = await _mediator.Send(new GetUserProfileQuery(login, password));
            if (!userProfile.Success)
            {
                return new GetUserProfileDto {UserWasFound = false};
            }

            return new GetUserProfileDto
            {
                Id = userProfile.Value.Id,
                FirstName = userProfile.Value.FirstName,
                LastName = userProfile.Value.LastName,
                UserWasFound = userProfile.Success
            };
        }
    }
}

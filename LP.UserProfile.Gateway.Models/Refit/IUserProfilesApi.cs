using System.Threading.Tasks;
using LP.UserProfile.Gateway.Dto;
using Refit;

namespace LP.UserProfile.Gateway.Refit
{
    public interface IUserProfilesApi
    {
        [Post("/userProfiles")]
        Task<bool> RegisterAsync([Body]RegisterNewProfileDto registerProfileDto);
    }



    ///// Registers a new profile 
    ///// </summary>
    ///// <param name="registerProfileModel">Profile data</param>
    ///// <returns>Is user profile was created successfully</returns>
    ///// <response code="400">Invalid input data</response>
    //[HttpPost]
    //[ProducesResponseType(typeof(ResponseError), 400)]
    //public async Task<bool> Post([FromBody]RegisterNewProfileDto registerProfileModel)
}

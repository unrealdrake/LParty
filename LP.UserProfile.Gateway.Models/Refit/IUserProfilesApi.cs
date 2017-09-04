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
}

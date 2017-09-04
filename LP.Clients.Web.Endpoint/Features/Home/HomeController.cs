using System.Threading.Tasks;
using LP.UserProfile.Gateway.Dto;
using LP.UserProfile.Gateway.Refit;
using Microsoft.AspNetCore.Mvc;
using Refit;
using Shared.Config;

namespace LP.Clients.Web.Endpoint.Features.Home
{
    public class HomeController : Controller
    {
        private readonly IUserProfilesApi _userProfilesApi = RestService.For<IUserProfilesApi>(Config.UserProfilesApi);

        [HttpGet]
        public IActionResult Index()
        {
            return View("~/Features/Home/Index/Index.cshtml");
        }

        [HttpPost]
        public async Task RegisterNewProfile(RegisterNewProfileDto registerProfileDto)
        {
            await _userProfilesApi.RegisterAsync(registerProfileDto);
        }
    }
}
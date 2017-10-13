using Microsoft.AspNetCore.Mvc;

namespace LP.Clients.Web.Endpoint.Features.Registration
{
    public class RegistrationController : Controller
    {
        [Route("Registration")]
        public IActionResult Index()
        {
            return View("~/Features/Registration/RegistrationPage/RegistrationPage.cshtml");
        }
    }
}
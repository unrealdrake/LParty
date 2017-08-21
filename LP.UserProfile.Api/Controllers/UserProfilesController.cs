using System.Threading.Tasks;
using LP.UserProfile.ApplicationService.Write.RegisterNewProfile;
using LP.UserProfile.Domain.User_Area.Core;
using Microsoft.AspNetCore.Mvc;
using LP.UserProfile.Gateway.Models;
using MediatR;

namespace LP.UserProfile.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserProfilesController : Controller
    {
        private readonly IMediator _mediator;

        public UserProfilesController(IMediator mediatr)
        {
            _mediator = mediatr;
        }

        //// GET api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task Post([FromBody]RegisterNewProfileModel model)
        {
            var address = Address.Factory.Create(model.City);
            var personalInformation = PersonalInformation.Factory.Create(model.FirstName, model.LastName);
            var loginData = LoginData.Factory.Create(model.Login);
            var user = Domain.User_Area.Core.User.Factory.Create(personalInformation, address, loginData);
            await _mediator.Send(new RegisterNewProfileCommand(user));
        }
    }
}

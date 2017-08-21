using Microsoft.AspNetCore.Mvc;
using LP.UserProfile.Gateway.Models;

namespace LP.UserProfile.Api.Controllers
{
    [Route("userProfile/api/[controller]")]
    public class UserProfilesController : Controller
    {
        //// GET api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        [HttpPost]
        public void Post([FromBody]RegisterNewProfileModel model)
        {
        }
    }
}

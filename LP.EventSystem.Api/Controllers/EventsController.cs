using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace LP.EventSystem.Api.Controllers
{
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}

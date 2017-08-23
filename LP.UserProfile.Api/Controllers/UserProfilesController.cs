using System.Collections.Generic;
using System.Threading.Tasks;
using LP.UserProfile.ApplicationService.Write.RegisterNewProfile;
using LP.UserProfile.Domain.User_Area.Core;
using LP.UserProfile.Domain.User_Area.Repositories;
using LP.UserProfile.Gateway.Models;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace LP.UserProfile.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserProfilesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IReadUserProfileRepository _readUserProfileRepository;

        public UserProfilesController(IMediator mediatr, IReadUserProfileRepository readUserProfileRepository)
        {
            _mediator = mediatr;
            _readUserProfileRepository = readUserProfileRepository;
        }

        //// GET api/values
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _readUserProfileRepository.GetAllUsers();
        }


        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Registers a new profile 
        /// </summary>
        /// <param name="registerProfileModel">Profile data</param>
        /// <returns>Is user profile was created successfully</returns>
        /// <response code="400">Invalid input data</response>
        [HttpPost]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<bool> Post([FromBody]RegisterNewProfileDto registerProfileModel)
        {
            return await _mediator.Send(new RegisterNewProfileCommand(registerProfileModel));
        }
    }
}

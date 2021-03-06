﻿using System.Threading.Tasks;
using LP.UserProfile.Api.Middlewares.ErrorHandling;
using LP.UserProfile.ApplicationService.Write.RegisterNewProfile;
using LP.UserProfile.Domain.User_Area.Repositories;
using LP.UserProfile.Gateway.Dto;
using Microsoft.AspNetCore.Mvc;
using MediatR;

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
        private readonly IReadUserProfileRepository _readUserProfileRepository;

        /// <inheritdoc />
        public UserProfilesController(IMediator mediatr, IReadUserProfileRepository readUserProfileRepository)
        {
            _mediator = mediatr;
            _readUserProfileRepository = readUserProfileRepository;
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
    }
}

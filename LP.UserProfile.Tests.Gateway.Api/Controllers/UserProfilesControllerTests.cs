using System;
using LP.UserProfile.ApplicationService.Write.RegisterNewProfile;
using LP.UserProfile.Domain.User_Area.Repositories;
using LP.UserProfile.Gateway.Models;
using LP.UserProfile.Tests.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.CompositionRoot;

namespace LP.UserProfile.Tests.Gateway.Api.Controllers
{
    [TestClass]
    public class UserProfilesControllerTests : BaseTestClass
    {
        private static IReadUserProfileRepository _readUserProfileRepository;
        RegisterNewProfileDto defaultNewProfile = new RegisterNewProfileDto
        {
            AddressCity = "London",
            FirstName = "Genny",
            LastName = "Motion",
            Login = "Graber"
        };

        [ClassInitialize]
        public static void PreInitConfiguration(TestContext testContext)
        {
            SetTestSettings();

            _readUserProfileRepository = ResolverRoot.Resolve<IReadUserProfileRepository>();
        }

        [TestMethod]
        public void TestMethod1()
        {
            defaultNewProfile.Login = Guid.NewGuid().ToString();
            bool createdSuccessfully = await _mediator.Send(new RegisterNewProfileCommand(defaultNewProfile));
        }
    }
}

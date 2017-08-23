using System;
using System.Linq;
using LP.UserProfile.ApplicationService.Write.RegisterNewProfile;
using LP.UserProfile.Tests.Shared;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.CompositionRoot;
using System.Threading.Tasks;
using LP.UserProfile.Domain.User_Area.Repositories;
using LP.UserProfile.Gateway.Models;

namespace LP.UserProfile.Tests.ApplicationService
{
    [TestClass]
    public class RegisterNewProfileTests : BaseTestClass
    {
        private static IMediator _mediator;
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
            _mediator = MediatorBuilder.BuildMediator();
            _readUserProfileRepository = ResolverRoot.Resolve<IReadUserProfileRepository>();
        }

        [TestMethod]
        public async Task CanNotCreateIfUserAlreadyExists()
        {
            var allUsers = _readUserProfileRepository.GetAllUsers();
            if (allUsers.Any())
            {
                var existingUser = allUsers.First();
                defaultNewProfile.Login = existingUser.LoginData.Login;
                bool createdSuccessfully = await _mediator.Send(new RegisterNewProfileCommand(defaultNewProfile));

                Assert.IsFalse(createdSuccessfully);
            }
        }

        [TestMethod]
        public async Task CreateIfUserAlreadyNotExists()
        {
            defaultNewProfile.Login = Guid.NewGuid().ToString();
            bool createdSuccessfully = await _mediator.Send(new RegisterNewProfileCommand(defaultNewProfile));

            Assert.IsTrue(createdSuccessfully);
        }
    }
}

using System;
using System.Linq;
using LP.UserProfile.ApplicationService.Write.RegisterNewProfile;
using LP.UserProfile.Tests.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.CompositionRoot;
using System.Threading.Tasks;
using LP.UserProfile.Domain.User_Area.Repositories;
using LP.UserProfile.Gateway.Dto;

namespace LP.UserProfile.Tests.ApplicationService
{
    [TestClass]
    public class RegisterNewProfileTests : BaseTestClass
    {
        private static IReadUserProfileRepository _readUserProfileRepository;

        readonly RegisterNewProfileDto _defaultNewProfile = new RegisterNewProfileDto
        {
            AddressCity = "London",
            FirstName = "Genny",
            LastName = "Motion",
            Login = "Graber",
            Password = "Password1"
        };

        [ClassInitialize]
        public static void PreInitConfiguration(TestContext testContext)
        {
            Init(testContext);
            _readUserProfileRepository = ResolverRoot.Resolve<IReadUserProfileRepository>();
        }

        [TestMethod]
        public async Task CanNotCreateIfUserAlreadyExists()
        {
            var allUsers = await _readUserProfileRepository.GetAllUsersAsync();
            if (allUsers.Any())
            {
                var existingUser = allUsers.First();
                _defaultNewProfile.Login = existingUser.LoginData.Login;
                bool createdSuccessfully = await Mediator.Send(new RegisterNewProfileCommand(_defaultNewProfile));

                Assert.IsFalse(createdSuccessfully);
            }
        }

        [TestMethod]
        public async Task CreateIfUserAlreadyNotExists()
        {
            _defaultNewProfile.Login = Guid.NewGuid().ToString();
            bool createdSuccessfully = await Mediator.Send(new RegisterNewProfileCommand(_defaultNewProfile));

            Assert.IsTrue(createdSuccessfully);
        }
    }
}

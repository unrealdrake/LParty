using System;
using System.Linq;
using LP.UserProfile.ApplicationService.Write.RegisterNewProfile;
using LP.UserProfile.Tests.Shared;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.CompositionRoot;
using System.Threading.Tasks;
using LP.UserProfile.Domain.User_Area.Core;
using LP.UserProfile.Domain.User_Area.Repositories;

namespace LP.UserProfile.Tests.ApplicationService
{
    [TestClass]
    public class RegisterNewProfileTests : BaseTestClass
    {
        private static IMediator _mediator;
        private static IReadUserProfileRepository _readUserProfileRepository;
        private readonly Address _defaultAddress = Address.Factory.Create("London");
        private readonly PersonalInformation _personalInformation = PersonalInformation.Factory.Create("Jack", "Smith");

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
                var newUser = User.Factory.Create(_personalInformation, _defaultAddress, LoginData.Factory.Create(existingUser.LoginData.Login));
                bool createdSuccessfully = await _mediator.Send(new RegisterNewProfileCommand(newUser));

                Assert.IsFalse(createdSuccessfully);
            }
        }

        [TestMethod]
        public async Task CreateIfUserAlreadyNotExists()
        {
            var newUser = User.Factory.Create(_personalInformation, _defaultAddress, LoginData.Factory.Create(Guid.NewGuid().ToString()));
            bool createdSuccessfully = await _mediator.Send(new RegisterNewProfileCommand(newUser));

            Assert.IsTrue(createdSuccessfully);
        }
    }
}

using System;
using System.Linq;
using LP.UserProfile.Domain.User_Area.DomainServices;
using LP.UserProfile.Domain.User_Area.Repositories;
using LP.UserProfile.Tests.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.CompositionRoot;

namespace LP.UserProfile.Tests.Domain.User_Area.DomainServices
{
    [TestClass]
    public class UserProfileDomainServicesTests : BaseTestClass
    {
        private static UserProfileDomainService _userProfileDomainService;
        private static IReadUserProfileRepository _readUserProfileRepository;

        [ClassInitialize]
        public static void PreInitConfiguration(TestContext testContext)
        {
            SetTestSettings();
            _userProfileDomainService = DependenciesRegistrator.Resolve<UserProfileDomainService>();
            _readUserProfileRepository = DependenciesRegistrator.Resolve<IReadUserProfileRepository>();
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void CheckAlreadyExistsEmptyLogin()
        {
            _userProfileDomainService.IsAlreadyExist("");
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void CheckAlreadyExistsNullLogin()
        {
            _userProfileDomainService.IsAlreadyExist(null);
        }

        [TestMethod]
        public void MustReturnTrueIfUserExists()
        {
            var allUsers = _readUserProfileRepository.GetAllUsers();
            if (allUsers.Any())
            {
                var user = allUsers.First();

                Assert.IsTrue(_userProfileDomainService.IsAlreadyExist(user.LoginData.Login));
            }
        }
    }
}

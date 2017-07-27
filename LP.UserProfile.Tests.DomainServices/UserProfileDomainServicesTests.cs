using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LP.UserProfile.DomainService;
using LP.UserProfile.Repository;
using Shared.CompositionRoot;
using LP.UserProfile.Tests.Shared;

namespace LP.UserProfile.Tests.DomainServices
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

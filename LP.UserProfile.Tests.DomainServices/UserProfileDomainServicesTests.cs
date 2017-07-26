using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LP.UserProfile.DomainService;
using Shared.CompositionRoot;
using LP.UserProfile.Tests.Shared;

namespace LP.UserProfile.Tests.DomainServices
{
    [TestClass]
    public class UserProfileDomainServicesTests : BaseTestClass
    {
        private static UserProfileDomainService _userProfileDomainService;

        [ClassInitialize]
        public static void PreInitConfiguration(TestContext testContext)
        {
            SetTestSettings();
            _userProfileDomainService = DependenciesRegistrator.Resolve<UserProfileDomainService>();
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
    }
}

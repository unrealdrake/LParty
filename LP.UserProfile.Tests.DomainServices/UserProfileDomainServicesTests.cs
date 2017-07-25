using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LP.UserProfile.DomainService;
using Shared.CompositionRoot;

namespace LP.UserProfile.Tests.DomainServices
{
    [TestClass]
    public class UserProfileDomainServicesTests
    {
        private static UserProfileDomainService _userProfileDomainService;

        [ClassInitialize]
        public static void PreInitConfiguration(TestContext testContext)
        {
            _userProfileDomainService = DependenciesRegistrator.Container().GetInstance<UserProfileDomainService>();
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void CheckAlreadyExistsEmptyLogin()
        {
            _userProfileDomainService.IsAlreadyExists("");
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void CheckAlreadyExistsNullLogin()
        {
            _userProfileDomainService.IsAlreadyExists(null);
        }
    }
}

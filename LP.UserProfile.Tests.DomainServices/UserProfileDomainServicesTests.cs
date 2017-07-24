using System;
using LP.UserProfile.EFRepository;
using LP.UserProfile.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LP.UserProfile.DomainService;

namespace LP.UserProfile.Tests.DomainServices
{
    [TestClass]
    public class UserProfileDomainServicesTests
    {
        private static UserProfileEFContext _context;
        private static IReadUserProfileRepository _readUsersRepository;
        private static UserProfileDomainService _userProfileDomainService;

        [ClassInitialize]
        public static void PreInitConfiguration(TestContext testContext)
        {
            _context = new UserProfileEFContext();
            _readUsersRepository = new ReadUserProfileRepository(_context);
            _userProfileDomainService = new UserProfileDomainService(_readUsersRepository);
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

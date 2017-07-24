using LP.UserProfile.DomainService;
using LP.UserProfile.EFRepository;
using LP.UserProfile.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LP.UserProfile.Tests.ApplicationService
{
    [TestClass]
    public class RegisterNewProfileTests
    {
        private static UserProfileEFContext _context;
        private static IReadUserProfileRepository _readUsersRepository;
        private static IWriteUserProfileRepository _writeUsersRepository;
        private static UserProfileDomainService _userProfileDomainService;

        [ClassInitialize]
        public static void PreInitConfiguration(TestContext testContext)
        {
            _context = new UserProfileEFContext();
            _readUsersRepository = new ReadUserProfileRepository(_context);
            _writeUsersRepository = new WriteUserProfileRepository(_context);
            _userProfileDomainService = new UserProfileDomainService(_readUsersRepository);
        }


        [TestMethod]
        public void Handle()
        {
        }
    }
}

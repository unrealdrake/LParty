using System;
using System.Linq;
using System.Threading.Tasks;
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
            Init(testContext);
            _userProfileDomainService = ResolverRoot.Resolve<UserProfileDomainService>();
            _readUserProfileRepository = ResolverRoot.Resolve<IReadUserProfileRepository>();
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public async Task CheckAlreadyExistsEmptyLogin()
        {
            await _userProfileDomainService.IsAlreadyExistAsync("");
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public async Task CheckAlreadyExistsNullLogin()
        {
            await _userProfileDomainService.IsAlreadyExistAsync(null);
        }

        [TestMethod]
        public async Task MustReturnTrueIfUserExists()
        {
            var allUsers = await _readUserProfileRepository.GetAllUsersAsync();
            if (allUsers.Any())
            {
                var user = allUsers.First();

                Assert.IsTrue(await _userProfileDomainService.IsAlreadyExistAsync(user.LoginData.Login));
            }
        }
    }
}

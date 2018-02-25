using System.Linq;
using System.Threading.Tasks;
using LP.UserProfile.ApplicationService.Read.GetUserProfile;
using LP.UserProfile.Domain.User_Area.Repositories;
using LP.UserProfile.Tests.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.CompositionRoot;

namespace LP.UserProfile.Tests.ApplicationService
{
    [TestClass]
    public class GetUserProfileTests : BaseTestClass
    {
        private static IReadUserProfileRepository _readUserProfileRepository;

        [ClassInitialize]
        public static void PreInitConfiguration(TestContext testContext)
        {
            Init(testContext);
            _readUserProfileRepository = ResolverRoot.Resolve<IReadUserProfileRepository>();
        }

        [TestMethod]
        public async Task GetExistingUserNotNull()
        {
            var existingUser = (await _readUserProfileRepository.GetAllUsersAsync()).FirstOrDefault();
            if (existingUser !=null)
            {
                var user = await Mediator.Send(new GetUserProfileQuery(existingUser.LoginData.Login, existingUser.LoginData.Password));

                Assert.IsNotNull(user);
            }
        }
    }
}

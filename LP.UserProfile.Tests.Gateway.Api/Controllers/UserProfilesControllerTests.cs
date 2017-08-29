using System.Threading.Tasks;
using LP.UserProfile.Domain.User_Area.Repositories;
using LP.UserProfile.Gateway.Models;
using LP.UserProfile.Tests.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.CompositionRoot;
using LP.UserProfile.Api.Controllers;

namespace LP.UserProfile.Tests.Gateway.Api.Controllers
{
    [TestClass]
    public class UserProfilesControllerTests : BaseTestClass
    {
        RegisterNewProfileDto defaultNewProfile = new RegisterNewProfileDto
        {
            AddressCity = "London",
            FirstName = "Genny",
            LastName = "Motion",
            Login = "GraberSon"
        };

        [ClassInitialize]
        public static void PreInitConfiguration(TestContext testContext)
        {
            Init(testContext);
        }

        [TestMethod]
        public async Task UserProfileMustBeCreated()
        {
            var userProfileController = ResolverRoot.Resolve<UserProfilesController>();
            var isCreated = await userProfileController.Post(defaultNewProfile);
            Assert.IsTrue(isCreated);
        }
    }
}

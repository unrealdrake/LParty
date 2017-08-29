using System.Threading.Tasks;
using LP.UserProfile.Gateway.Models;
using LP.UserProfile.Tests.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.CompositionRoot;
using LP.UserProfile.Api.Controllers;
using SharedKernel.Infrastructure;

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

        [TestMethod]
        [ExpectedException(typeof(ValidatableObjectIsInvalidException))]
        public async Task UserProfileMustProduce400ErrorIfInvalidaData()
        {
            var userProfileController = ResolverRoot.Resolve<UserProfilesController>();
            defaultNewProfile.FirstName = null;
            await userProfileController.Post(defaultNewProfile);
        }
    }
}

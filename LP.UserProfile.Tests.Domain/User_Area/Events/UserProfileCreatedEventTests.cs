using LP.UserProfile.Domain.User_Area.Core;
using LP.UserProfile.Domain.User_Area.DomainServices;
using LP.UserProfile.Domain.User_Area.Events;
using LP.UserProfile.Domain.User_Area.Repositories;
using LP.UserProfile.Tests.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.CompositionRoot;
using SharedKernel.DomainEvents;

namespace LP.UserProfile.Tests.Domain.User_Area.Events
{
    [TestClass]
    public class UserProfileCreatedEventTests : BaseTestClass
    {
        private readonly Address _defaultAddress = Address.Factory.Create("London");
        private readonly PersonalInformation _personalInformation = PersonalInformation.Factory.Create("Jack", "Smith");
        private readonly LoginData _loginData = LoginData.Factory.Create("Games");
        private static User _defaultProfile;

        private static UserProfileDomainService _userProfileDomainService;
        private static IWriteUserProfileRepository _writeUserProfileRepository;

        public UserProfileCreatedEventTests()
        {
            _defaultProfile = User.Factory.Create(_personalInformation, _defaultAddress, _loginData);
        }

        [ClassInitialize]
        public static void PreInitConfiguration(TestContext testContext)
        {
            Init(testContext);
            _userProfileDomainService = ResolverRoot.Resolve<UserProfileDomainService>();
            _writeUserProfileRepository = ResolverRoot.Resolve<IWriteUserProfileRepository>();
        }

        [TestMethod]
        public void UserProfileCreatedEventRaised()
        {
            _writeUserProfileRepository.ClearAll();
            DomainEvents.Register<UserProfileCreatedEvent>((ev) =>
            {
                Assert.AreEqual(_defaultProfile.Id, ev.UserProfileId);
            });
            _userProfileDomainService.RegisterNewProfile(_defaultProfile);
        }
    }
}

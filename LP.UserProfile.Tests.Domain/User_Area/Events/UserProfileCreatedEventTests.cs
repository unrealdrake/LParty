using LP.UserProfile.Domain.User_Area.Core;
using LP.UserProfile.Domain.User_Area.Events;
using LP.UserProfile.Tests.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharedKernel.DomainEvents;

namespace LP.UserProfile.Tests.Domain.User_Area.Events
{
    [TestClass]
    public class UserProfileCreatedEventTests : BaseTestClass
    {
        private readonly Address _defaultAddress = Address.Factory.Create("London");
        private readonly PersonalInformation _personalInformation = PersonalInformation.Factory.Create("Jack", "Smith");
        private readonly LoginData _loginData = LoginData.Factory.Create("Games");

        [TestMethod]
        public void UserProfileCreatedEventRaised()
        {
            var testUser = User.Factory.Create(_personalInformation, null, _loginData);
            DomainEvents.Register<UserProfileCreatedEvent>((ev)=> testUser.Id == ev.UserProfileId);
            User.Factory.Create(_personalInformation, null, _loginData);
        }
    }
}

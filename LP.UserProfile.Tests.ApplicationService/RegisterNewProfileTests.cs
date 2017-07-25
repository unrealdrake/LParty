using LP.UserProfile.ApplicationService.Write.RegisterNewProfile;
using LP.UserProfile.Domain.User_Area;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.CompositionRoot;

namespace LP.UserProfile.Tests.ApplicationService
{
    [TestClass]
    public class RegisterNewProfileTests
    {
        private static IMediator _mediator;
        private readonly Address _defaultAddress = Address.Factory.Create("London");
        private readonly PersonalInformation _personalInformation = PersonalInformation.Factory.Create("Jack", "Smith");
        private readonly LoginData _loginData = LoginData.Factory.Create("Granny");

        [ClassInitialize]
        public static void PreInitConfiguration(TestContext testContext)
        {
            _mediator = MediatorBuilder.BuildMediator();

        }

        [TestMethod]
        public void Handle()
        {
            var user = User.Factory.Create(_personalInformation, _defaultAddress, _loginData);
            var response = _mediator.Send(new RegisterNewProfileCommand(user)).Result;
        }
    }
}

using LP.UserProfile.ApplicationService.Write.RegisterNewProfile;
using LP.UserProfile.Domain.User_Area;
using LP.UserProfile.Tests.Shared;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.CompositionRoot;
using System.Threading.Tasks;

namespace LP.UserProfile.Tests.ApplicationService
{
    [TestClass]
    public class RegisterNewProfileTests : BaseTestClass
    {
        private static IMediator _mediator;
        private readonly Address _defaultAddress = Address.Factory.Create("London");
        private readonly PersonalInformation _personalInformation = PersonalInformation.Factory.Create("Jack", "Smith");
        private readonly LoginData _loginData = LoginData.Factory.Create("Granny");

        [ClassInitialize]
        public static void PreInitConfiguration(TestContext testContext)
        {
            SetTestSettings();
            _mediator = MediatorBuilder.BuildMediator();
        }

        [TestMethod]
        public async Task Handle()
        {
            var user = User.Factory.Create(_personalInformation, _defaultAddress, _loginData);
            var response = await _mediator.Send(new RegisterNewProfileCommand(user));
        }
    }
}

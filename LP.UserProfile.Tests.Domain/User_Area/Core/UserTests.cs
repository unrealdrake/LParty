using System;
using LP.UserProfile.Domain.User_Area.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LP.UserProfile.Tests.Domain.User_Area.Core
{
    [TestClass]
    public class UserTests
    {
        private readonly Address _defaultAddress = Address.Factory.Create("London");
        private readonly PersonalInformation _personalInformation = PersonalInformation.Factory.Create("Jack", "Smith");
        private readonly LoginData _loginData = LoginData.Factory.Create("Granny");

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CannotCreateUserWithoutAddress()
        {
            User.Factory.Create(_personalInformation, null, _loginData);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CannotCreateUserWithoutPersonalInformation()
        {
            User.Factory.Create(null, _defaultAddress, _loginData);
        }
    }
}

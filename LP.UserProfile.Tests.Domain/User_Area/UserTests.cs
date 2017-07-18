using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LP.UserProfile.Domain.User_Area;

namespace LP.UserProfile.Tests.Domain.User_Area
{
    [TestClass]
    public class UserTests
    {
        private readonly Address _defaultAddress = Address.Factory.Create("London");
        private readonly PersonalInformation _personalInformation = PersonalInformation.Factory.Create("Jack", "Smith");

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CannotCreateUserWithoutAddress()
        {
            User.Factory.Create(_personalInformation, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CannotCreateUserWithoutPersonalInformation()
        {
            User.Factory.Create(null, _defaultAddress);
        }
    }
}

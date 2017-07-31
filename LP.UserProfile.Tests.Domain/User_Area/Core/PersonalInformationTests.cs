using LP.UserProfile.Domain.User_Area.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharedKernel.Infrastructure;

namespace LP.UserProfile.Tests.Domain.User_Area.Core
{
    [TestClass]
    public class PersonalInformationTests
    {
        [TestMethod]
        [ExpectedException(typeof(ValidatableObjectIsInvalidException))]
        public void CannotCreateWithTooLongFirstName()
        {
            string firstNameWith26Chars = "ghoklorpelffontmfntmtodmtn";
            PersonalInformation.Factory.Create(firstNameWith26Chars, "last name");
        }

        [TestMethod]
        [ExpectedException(typeof(ValidatableObjectIsInvalidException))]
        public void CannotCreateWithTooLongLastName()
        {
            string lastNameWith31Chars = "ghoklorpelffontmfntmtodmtnwrflo";
            PersonalInformation.Factory.Create("first name", lastNameWith31Chars);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void CannotCreateWithNullFirstOrLastName()
        {
            PersonalInformation.Factory.Create(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidatableObjectIsInvalidException))]
        public void CannotCreateWithEmptyFirstOrLastName()
        {
            PersonalInformation.Factory.Create("", "");
        }
    }
}

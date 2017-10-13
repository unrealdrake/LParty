using LP.UserProfile.Tests.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.CompositionRoot;
using System.Linq;
using LP.UserProfile.Domain.User_Area.Core;
using LP.UserProfile.Domain.User_Area.Repositories;

namespace LP.UserProfile.Tests.EFRepository
{
    [TestClass]
    public class UsersRepositoryTests: BaseTestClass
    {
        private static IReadUserProfileRepository _readUsersRepository;
        private static IWriteUserProfileRepository _writeUsersRepository;
        private static User defaultUser;
        private static PersonalInformation defaultPersonalInformation;
        private static Address defaultAddress;
        private static LoginData loginData;

        [ClassInitialize]
        public static void PreInitConfiguration(TestContext testContext)
        {
            Init(testContext);

            _readUsersRepository = ResolverRoot.Resolve<IReadUserProfileRepository>();
            _writeUsersRepository = ResolverRoot.Resolve<IWriteUserProfileRepository>();

            defaultPersonalInformation = PersonalInformation.Factory.Create(firstName: "Jack", lastName: "Simon");
            defaultAddress = Address.Factory.Create(city: "London");
            loginData = LoginData.Factory.Create(login: "Simth", password: "Slavert40");
            defaultUser = User.Factory.Create(defaultPersonalInformation, defaultAddress, loginData);
        }

        [TestMethod]
        public void GetUsers_NotFails()
        {
            _readUsersRepository.GetAllUsers();
        }

        [TestMethod]
        public void AddNewUser_NotFails()
        {
            int allUsersCount = _readUsersRepository.GetAllUsers().Count();
            _writeUsersRepository.AddNewProfile(defaultUser);
            int allUsersCountAfterSaving = _readUsersRepository.GetAllUsers().Count();
            Assert.AreEqual(allUsersCount + 1, allUsersCountAfterSaving);
        }

        [TestMethod]
        public void DeleteExistingUser_NotFails()
        {
            var existingUser = _readUsersRepository.GetAllUsers().FirstOrDefault();
            int allUsersCount = _readUsersRepository.GetAllUsers().Count();
            if (existingUser != null)
            {
                _writeUsersRepository.Delete(existingUser);
            }
            int allUsersCountAfterSaving = _readUsersRepository.GetAllUsers().Count();
            Assert.AreEqual(allUsersCount - 1, allUsersCountAfterSaving);
        }
    }
}

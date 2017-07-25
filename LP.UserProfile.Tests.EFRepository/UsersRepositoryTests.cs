using LP.UserProfile.Domain.User_Area;
using LP.UserProfile.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.CompositionRoot;
using System.Linq;

namespace LP.UserProfile.Tests.EFRepository
{
    [TestClass]
    public class UsersRepositoryTests
    {
        private static IWriteUserProfileRepository _writeUsersRepository;
        private static User defaultUser;
        private static PersonalInformation defaultPersonalInformation;
        private static Address defaultAddress;
        private static LoginData loginData;

        [ClassInitialize]
        public static void PreInitConfiguration(TestContext testContext)
        {
            _writeUsersRepository = DependenciesRegistrator.Resolve<IWriteUserProfileRepository>();

            defaultPersonalInformation = PersonalInformation.Factory.Create(firstName: "Jack", lastName: "Simon");
            defaultAddress = Address.Factory.Create(city: "London");
            loginData = LoginData.Factory.Create(login: "Simth");
            defaultUser = User.Factory.Create(defaultPersonalInformation, defaultAddress, loginData);
        }

        [TestMethod]
        public void GetUsers_NotFails()
        {
            _writeUsersRepository.GetAllUsers();
        }

        [TestMethod]
        public void AddNewUser_NotFails()
        {
            int allUsersCount = _writeUsersRepository.GetAllUsers().Count();
            _writeUsersRepository.AddNewProfile(defaultUser);
            int allUsersCountAfterSaving = _writeUsersRepository.GetAllUsers().Count();
            Assert.AreEqual(allUsersCount + 1, allUsersCountAfterSaving);
        }

        [TestMethod]
        public void DeleteExistingUser_NotFails()
        {
            var existingUser = _writeUsersRepository.GetAllUsers().FirstOrDefault();
            int allUsersCount = _writeUsersRepository.GetAllUsers().Count();
            if (existingUser != null)
            {
                _writeUsersRepository.Delete(existingUser);
            }
            int allUsersCountAfterSaving = _writeUsersRepository.GetAllUsers().Count();
            Assert.AreEqual(allUsersCount - 1, allUsersCountAfterSaving);
        }

        [TestCleanup]
        public void CleanDatabse()
        {
            
        }
    }
}

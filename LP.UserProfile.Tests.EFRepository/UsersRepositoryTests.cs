using LP.UserProfile.Tests.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.CompositionRoot;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task GetUsers_NotFails()
        {
            await _readUsersRepository.GetAllUsersAsync();
        }

        [TestMethod]
        public async Task AddNewUser_NotFails()
        {
            int allUsersCount = (await _readUsersRepository.GetAllUsersAsync()).Count();
            await _writeUsersRepository.AddNewProfileAsync(defaultUser);
            int allUsersCountAfterSaving = (await _readUsersRepository.GetAllUsersAsync()).Count();
            Assert.AreEqual(allUsersCount + 1, allUsersCountAfterSaving);
        }

        [TestMethod]
        public async Task DeleteExistingUser_NotFails()
        {
            var existingUser = (await _readUsersRepository.GetAllUsersAsync()).FirstOrDefault();
            int allUsersCount = (await _readUsersRepository.GetAllUsersAsync()).Count();
            if (existingUser != null)
            {
                await _writeUsersRepository.DeleteAsync(existingUser);
            }
            int allUsersCountAfterSaving = (await _readUsersRepository.GetAllUsersAsync()).Count();
            Assert.AreEqual(allUsersCount - 1, allUsersCountAfterSaving);
        }
    }
}

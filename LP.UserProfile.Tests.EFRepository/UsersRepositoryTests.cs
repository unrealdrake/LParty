using LP.UserProfile.Domain.User_Area;
using LP.UserProfile.EFRepository;
using LP.UserProfile.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LP.UserProfile.Tests.EFRepository
{
    [TestClass]
    public class UsersRepositoryTests
    {
        private static UserProfileEFContext _context;
        private static IUserProfileRepository _usersRepository;
        private static User defaultUser;
        private static PersonalInformation defaultPersonalInformation;
        private static Address defaultAddress;

        [ClassInitialize]
        public static void PreInitConfiguration(TestContext testContext)
        {
            _context = new UserProfileEFContext();
            _usersRepository = new UserProfileRepository(_context);

            defaultPersonalInformation = PersonalInformation.Factory.Create(firstName: "Jack", lastName: "Simon");
            defaultAddress = Address.Factory.Create(city: "London");
            defaultUser = User.Factory.Create(defaultPersonalInformation, defaultAddress);
        }

        [TestMethod]
        public void GetUsers_NotFails()
        {
           _usersRepository.GetAllUsers();
        }

        [TestMethod]
        public void AddAndDeleteNewUser()
        {
            _usersRepository.AddNewProfile(defaultUser);
        }
    }
}

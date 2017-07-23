using LP.UserProfile.Domain.User_Area;
using LP.UserProfile.EFRepository;
using LP.UserProfile.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LP.UserProfile.Tests.EFRepository
{
    [TestClass]
    public class UsersRepositoryTests
    {
        private UserProfileEFContext _context;
        private IUserProfileRepository _usersRepository;
        private User defaultUser;
        private PersonalInformation defaultPersonalInformation;
        private Address defaultAddress;

        [TestInitialize]
        public void PreInitConfiguration()
        {
            _context = new UserProfileEFContext();
            _usersRepository = new UserProfileRepository(_context);

            _usersRepository.ClearAll();

            defaultPersonalInformation = PersonalInformation.Factory.Create(firstName: "Jack", lastName: "Simon");
            defaultAddress = Address.Factory.Create(city: "London");
            User defaultUser = User.Factory.Create(defaultPersonalInformation, defaultAddress);
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

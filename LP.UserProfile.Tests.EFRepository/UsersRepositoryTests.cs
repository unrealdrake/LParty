using LP.UserProfile.EFRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LP.UserProfile.Tests.EFRepository
{
    [TestClass]
    public class UsersRepositoryTests
    {
        private UserProfileEFContext _context;
        private UsersRepository _usersRepository;

        [TestInitialize]
        public void PreInitConfiguration()
        {
            _context = new UserProfileEFContext();
            _usersRepository = new UsersRepository(_context);
        }

        [TestMethod]
        public void GetUsers_NotFails()
        {
           var s = _usersRepository.GetUsers();
        }
    }
}

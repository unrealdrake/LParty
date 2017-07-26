using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Infrasctructure.EntityFramework;

namespace Shared.Infrasctructure.Tests
{
    [TestClass]
    public class ConnectionStringFactoryTests
    {
        [TestMethod]
        public void MustReturnNotNullOrEmptyConectionString()
        {
            var defaultConnectionString = ConnectionStringFactory.Create();
            var connectionStringForTests = ConnectionStringFactory.Create(useTestConnectionString: true);
            
            Assert.IsFalse(string.IsNullOrEmpty(defaultConnectionString));
            Assert.IsFalse(string.IsNullOrEmpty(connectionStringForTests));
        }
    }
}

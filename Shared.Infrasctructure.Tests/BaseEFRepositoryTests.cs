using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Infrasctructure.EntityFramework;

namespace Shared.Infrasctructure.Tests
{
    internal class FakeBaseEFRepository : BaseEFRepository
    {
        public FakeBaseEFRepository(DbContext context) : base(context)
        {
        }
        
        public void TestMethod() { }
    }

    [TestClass]
    public class BaseEFRepositoryTests
    {
        [ExpectedException(typeof(ObjectDisposedException))]
        [TestMethod]
        public void ContextMustBeDisposedAfterUsing()
        {
            var dbContex = new DbContext(new DbContextOptionsBuilder<DbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);
            using (var fakeRepository = new FakeBaseEFRepository(dbContex))
            {
                
            }
            
            var model = dbContex.Model;
        }
    }
}

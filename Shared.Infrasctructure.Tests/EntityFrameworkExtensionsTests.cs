using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Infrasctructure.EntityFramework;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shared.Infrasctructure.Tests
{
    internal class TestUser
    {
        public int Id { get; set; }
    }

    internal class TestUserConfiguration : DbEntityConfiguration<TestUser>
    {
        public override void Configure(EntityTypeBuilder<TestUser> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
        }
    }

    internal class TestDbContext : DbContext
    {
        public DbSet<TestUser> TestUsers { get; set; }
        public TestDbContext(DbContextOptions options): base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddConfiguration(new TestUserConfiguration());
        }
    }
    
    [TestClass]
    public class EntityFrameworkExtensionsTests
    {
        private readonly TestDbContext _inMemoryTestsContext = new TestDbContext(new DbContextOptionsBuilder<TestDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);

        [TestMethod]
        public void DbSetMustBeClearedAfterCallingClear()
        {
            _inMemoryTestsContext.TestUsers.Add(new TestUser());
            _inMemoryTestsContext.SaveChanges();
            Assert.AreEqual(1, _inMemoryTestsContext.TestUsers.Count());

            _inMemoryTestsContext.TestUsers.Clear();
            _inMemoryTestsContext.SaveChanges();
            Assert.AreEqual(0, _inMemoryTestsContext.TestUsers.Count());
        }
    }
}

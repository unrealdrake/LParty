using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Infrasctructure.ObjectExtensions;

namespace Shared.Infrasctructure.Tests
{
    [TestClass]
    public class ObjectExtensionsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NullObjectMustProduceExceptionOnChecking()
        {
            string testObject = null;
            testObject.NotNull();
        }
    }
}

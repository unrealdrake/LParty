using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Infrasctructure.ObjectExtensions;

namespace Shared.Infrasctructure.Tests
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NullStringMustProduceExceptionOnChecking()
        {
            string testObject = null;
            testObject.NotNullOrEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyStringMustProduceExceptionOnChecking()
        {
            string testObject = "";
            testObject.NotNullOrEmpty();
        }
    }
}

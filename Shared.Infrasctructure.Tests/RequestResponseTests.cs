using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.Infrasctructure.ObjectExtensions;
using Shared.Infrasctructure.RequestResponse;

namespace Shared.Infrasctructure.Tests
{
    internal enum TestEnum
    {
        Value
    }
    
    [TestClass]
    public class RequestResponseTests
    {
        [TestMethod]
        public void NotSuccessIfHasAnyErrorsInResponse()
        {
            var response = new BaseResponse();
            response.Exceptions.Add(TestEnum.Value);
            
            Assert.IsFalse(response.Success);
        }

        [TestMethod]
        public void ErrorsMessageMustNotBeEmptyIfExceptionsInResponse()
        {
            var response = new BaseResponse();
            response.Exceptions.Add(TestEnum.Value);

            Assert.IsTrue(!string.IsNullOrEmpty(response.ErrorsMessage));
        }
    }
}

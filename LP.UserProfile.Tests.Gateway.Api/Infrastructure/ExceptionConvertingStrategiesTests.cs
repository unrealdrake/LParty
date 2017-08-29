using System;
using System.Collections.Generic;
using System.Net;
using FluentValidation.Results;
using LP.UserProfile.Api.Middlewares.ErrorHandling;
using LP.UserProfile.Gateway.ErrorCodes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharedKernel.Infrastructure;

namespace LP.UserProfile.Tests.Gateway.Api.Infrastructure
{
    [TestClass]
    public class ExceptionConvertingStrategiesTests
    {
        [TestMethod]
        public void ArgumentExceptionMustProduceBadRequestStatusCode()
        {
            var argumentException = new ArgumentException("Error message");
            var converted = argumentException.ToHttpStatusCode();

            Assert.AreEqual(converted.code, HttpStatusCode.BadRequest);
            Assert.AreEqual(converted.innerCode, InnerErrorCode.IncorrectInputData);
        }

        [TestMethod]
        public void ValidatableObjectIsInvalidExceptionMustProduceBadRequestStatusCode()
        {
            var argumentException = new ValidatableObjectIsInvalidException("Error message", new List<ValidationFailure>());
            var converted = argumentException.ToHttpStatusCode();

            Assert.AreEqual(converted.code, HttpStatusCode.BadRequest);
            Assert.AreEqual(converted.innerCode, InnerErrorCode.IncorrectInputData);
        }

        [TestMethod]
        public void ExceptionMustProduceInternalServerErrorStatusCode()
        {
            var argumentException = new Exception("Error message");
            var converted = argumentException.ToHttpStatusCode();

            Assert.AreEqual(converted.code, HttpStatusCode.InternalServerError);
            Assert.AreEqual(converted.innerCode, InnerErrorCode.UnhandledServerError);
        }
    }
}

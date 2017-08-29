using System;
using System.Net;
using System.Threading.Tasks;
using LP.UserProfile.Api.Middlewares.ErrorHandling;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LP.UserProfile.Tests.Gateway.Api.Infrastructure
{
    [TestClass]
    public class ErrorHandlingMiddlewareTests
    {
        [TestMethod]
        public async Task ErrorHandlingMiddlewareMustCallNextDelegate()
        {
            var delegateWasExecuted = false;
            Task ReqDelegate(HttpContext context)
            {
                delegateWasExecuted = true;
                return Task.CompletedTask;
            }

            ErrorHandlingMiddleware errorHandlingMiddleware = new ErrorHandlingMiddleware(ReqDelegate);
            await errorHandlingMiddleware.Invoke(new DefaultHttpContext());

            Assert.IsTrue(delegateWasExecuted);
        }

        [TestMethod]
        public async Task ErrorInDeDelegateMustBeConvertedToResponseError()
        {
            Task ReqDelegate(HttpContext context)
            {
                throw new Exception("Unhandled");
            }
            DefaultHttpContext defaultHttpContext = new DefaultHttpContext();
            ErrorHandlingMiddleware errorHandlingMiddleware = new ErrorHandlingMiddleware(ReqDelegate);
            await errorHandlingMiddleware.Invoke(defaultHttpContext);

            Assert.IsTrue(defaultHttpContext.Response.StatusCode == (int)HttpStatusCode.InternalServerError);
        }
    }
}

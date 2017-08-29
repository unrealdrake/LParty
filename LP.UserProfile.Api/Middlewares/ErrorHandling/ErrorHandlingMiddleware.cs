using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace LP.UserProfile.Api.Middlewares.ErrorHandling
{
    /// <summary>
    /// Error middleware
    /// </summary>
    public sealed class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Error middleware constructor
        /// </summary>
        /// <param name="next"></param>
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invoke delegate from http context
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var httpCodeWithMessage = exception.ToHttpStatusCode();
            var responseError = JsonConvert.SerializeObject(new ResponseError { MessageError = httpCodeWithMessage.message, InnerErrorCode = httpCodeWithMessage.innerCode });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)httpCodeWithMessage.code;

            return context.Response.WriteAsync(responseError);
        }
    }
}

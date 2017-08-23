using System;
using System.Net;
using SharedKernel.Infrastructure;

namespace LP.UserProfile.Api.Middlewares.ErrorHandling
{
    internal static class ExceptionConvertingStrategies
    {
        public static (HttpStatusCode code, string message) ToHttpStatusCode(this Exception generalException)
        {
            switch (generalException)
            {
                case ValidatableObjectIsInvalidException ex:
                {
                    return (HttpStatusCode.BadRequest, ex.Message);
                }
                case ArgumentException ex:
                {
                    return (HttpStatusCode.BadRequest, ex.Message);
                }
                default:
                {
                    return (HttpStatusCode.InternalServerError, "Internal server error were detected");
                }
            }
        }
    }
}

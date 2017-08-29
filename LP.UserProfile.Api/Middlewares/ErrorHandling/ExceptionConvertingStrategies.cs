using System;
using System.Net;
using LP.UserProfile.Gateway.ErrorCodes;
using SharedKernel.Infrastructure;

namespace LP.UserProfile.Api.Middlewares.ErrorHandling
{
    public static class ExceptionConvertingStrategies
    {
        public static (HttpStatusCode code, string message, InnerErrorCode innerCode) ToHttpStatusCode(this Exception generalException)
        {
            switch (generalException)
            {
                case ValidatableObjectIsInvalidException ex:
                {
                    return (HttpStatusCode.BadRequest, ex.Message, InnerErrorCode.IncorrectInputData);
                }
                case ArgumentException ex:
                {
                    return (HttpStatusCode.BadRequest, ex.Message, InnerErrorCode.IncorrectInputData);
                }
                default:
                {
                    return (HttpStatusCode.InternalServerError, "Internal server error were detected", InnerErrorCode.UnhandledServerError);
                }
            }
        }
    }
}

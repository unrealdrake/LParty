using System;
using System.Net;
using LP.UserProfile.Gateway.ErrorCodes;
using SharedKernel.Infrastructure;

namespace LP.UserProfile.Api.Middlewares.ErrorHandling
{
    /// <summary>
    /// Converting exceptions area
    /// </summary>
    public static class ExceptionConvertingStrategies
    {
        /// <summary>
        /// Converts Exception to HttpStatusCode with message and innerCode
        /// </summary>
        /// <param name="generalException"></param>
        /// <returns></returns>
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

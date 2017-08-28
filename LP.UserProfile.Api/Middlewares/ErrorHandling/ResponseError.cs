using LP.UserProfile.Gateway.ErrorCodes;

namespace LP.UserProfile.Api.Middlewares.ErrorHandling
{
    /// <summary>
    /// Response error
    /// </summary>
    public sealed class ResponseError
    {
        /// <summary>
        /// Message with error
        /// </summary>
        public string MessageError { get; set; }
        /// <summary>
        /// Innver code of error
        /// </summary>
        public InnerErrorCode InnerErrorCode { get; set; }
    }
}

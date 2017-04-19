using System;

namespace SharedKernel.Infrastructure
{
    public sealed class ValidatableObjectIsInvalidException: Exception
    {
        public ValidatableObjectIsInvalidException(string message) : base(message) {}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace SharedKernel.Infrastructure
{
    public sealed class ValidatableObjectIsInvalidException : Exception
    {
        public IList<ValidationFailure> Failures;

        public ValidatableObjectIsInvalidException(IList<ValidationFailure> failures) :
            base(string.Join(",", failures.Select(failure => failure.ErrorMessage)))
        {
            Failures = failures;
        }
    }
}

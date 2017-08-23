using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace SharedKernel.Infrastructure
{
    public sealed class ValidatableObjectIsInvalidException : Exception
    {
        public IList<ValidationFailure> Failures;
        public string PropertyName;

        public ValidatableObjectIsInvalidException(string propertyName, IList<ValidationFailure> failures) :
            base($"Property '{propertyName}' validation failures - " + string.Join(",", failures.Select(failure => failure.ErrorMessage)))
        {
            Failures = failures;
            PropertyName = propertyName;
        }
    }
}

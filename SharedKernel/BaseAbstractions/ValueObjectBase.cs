using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using SharedKernel.Infrastructure;

namespace SharedKernel.BaseAbstractions
{
    public abstract class ValueObjectBase<T> : IEquatable<T> where T: ValueObjectBase<T>
    {
        public abstract bool Equals(T other);
        public abstract override bool Equals(object obj);
        public abstract override int GetHashCode();

        protected void EnsureIsValid<T>(AbstractValidator<T> validator, T valueToValidate, bool checkForNull = true)
        {
            ValidationResult validationResult = validator.Validate(valueToValidate);
            IList<ValidationFailure> failures = validationResult.Errors;
            if (!validationResult.IsValid) throw new ValidatableObjectIsInvalidException(validationResult.Errors.Join(","))
        }
    }
}

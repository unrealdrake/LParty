using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;
using SharedKernel.Infrastructure;

namespace SharedKernel.BaseAbstractions
{
    public abstract class ValidatableObject
    {
        protected void EnsureIsValid<T>(AbstractValidator<T> validator, T valueToValidate, string propertyName, bool checkForNull = true)
        {
            if (checkForNull && object.Equals(valueToValidate, default(T)))
            {
                var nullValidation = new ValidationFailure("Root property", "Can not be null");
                throw new ValidatableObjectIsInvalidException(propertyName, new List<ValidationFailure> { nullValidation });
            }

            var validationResult = validator.Validate(valueToValidate);
            if (!validationResult.IsValid)
                throw new ValidatableObjectIsInvalidException(propertyName, validationResult.Errors);
        }
    }
}

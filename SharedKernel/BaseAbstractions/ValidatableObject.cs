using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;
using SharedKernel.Infrastructure;

namespace SharedKernel.BaseAbstractions
{
    public abstract class ValidatableObject
    {
        protected void EnsureIsValid<T>(AbstractValidator<T> validator, T valueToValidate, bool checkForNull = true)
        {
            ValidationResult validationResult = validator.Validate(valueToValidate);
            if (checkForNull && object.Equals(valueToValidate, default(T)))
            {
                validationResult.Errors.Add(new ValidationFailure("Root property", "Can not be null"));
            }
            if (!validationResult.IsValid)
                throw new ValidatableObjectIsInvalidException(validationResult.Errors);
        }

        protected void EnsureNotNull(object objectToValidate)
        {
            if (objectToValidate == null)
            {
                throw new ValidatableObjectIsInvalidException(new List<ValidationFailure>{ new ValidationFailure("Object property", "Can not be null")});
            }
        }
    }
}

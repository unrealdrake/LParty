using FluentValidation;
using FluentValidation.Results;
using SharedKernel.Infrastructure;

namespace SharedKernel.BaseAbstractions
{
    public abstract class ValidatableObject
    {
        protected void EnsureIsValid<T>(AbstractValidator<T> validator, T valueToValidate, string propertyName, bool checkForNull = true)
        {
            ValidationResult validationResult = new ValidationResult();
            if (checkForNull && object.Equals(valueToValidate, default(T)))
            {
                validationResult.Errors.Add(new ValidationFailure("Root property", "Can not be null"));
            }
            validator.Validate(valueToValidate);
            if (!validationResult.IsValid)
                throw new ValidatableObjectIsInvalidException(propertyName, validationResult.Errors);
        }
    }
}

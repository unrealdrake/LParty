using FluentValidation;

namespace LP.UserProfile.Domain.User_Area.Core.Validators
{
    internal sealed class FirstNameValidator : AbstractValidator<string>
    {
        public FirstNameValidator()
        {
            RuleFor(firstName => firstName).NotEmpty();
            RuleFor(firstName => firstName.Length).GreaterThan(0).LessThan(25);
        }
    }
}

using FluentValidation;

namespace LP.UserProfile.Domain.User_Area.Core.Validators
{
    internal sealed class LastNameValidator: AbstractValidator<string>
    {
        public LastNameValidator()
        {
            RuleFor(lastName => lastName).NotEmpty();
            RuleFor(lastName => lastName.Length).GreaterThan(0).LessThan(30);
        }
    }
}

using FluentValidation;

namespace LPBusiness.Domain.User_Area.Validators
{
    public sealed class FirstNameValidator : AbstractValidator<string>
    {
        public FirstNameValidator()
        {
            RuleFor(country => country).NotEmpty();
            RuleFor(country => country.Length).GreaterThan(0).LessThan(25);
        }
    }
}

using FluentValidation;

namespace LPBusiness.Domain.User_Area.Validators
{
    public sealed class LastNameValidator: AbstractValidator<string>
    {
        public LastNameValidator()
        {
            RuleFor(country => country).NotEmpty();
            RuleFor(country => country.Length).GreaterThan(0).LessThan(30);
        }
    }
}

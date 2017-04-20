using FluentValidation;

namespace Domain.Address_Area.Validators
{
    public sealed class CountryValidator: AbstractValidator<string>
    {
        public CountryValidator()
        {
            RuleFor(country => country).NotEmpty();
            RuleFor(country => country.Length).GreaterThan(0).LessThan(50);
        }
    }
}

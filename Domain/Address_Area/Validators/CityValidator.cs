using FluentValidation;

namespace Domain.Address_Area.Validators
{
    public sealed class CityValidator:AbstractValidator<string>
    {
        public CityValidator()
        {
            RuleFor(country => country).NotEmpty();
            RuleFor(country => country.Length).GreaterThan(0).LessThan(40);
        }
    }
}

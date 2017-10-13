using FluentValidation;

namespace LP.UserProfile.Domain.User_Area.Core.Validators
{
    internal sealed class CityValidator : AbstractValidator<string>
    {
        public CityValidator()
        {
            RuleFor(country => country).NotEmpty();
            RuleFor(country => country.Length).GreaterThan(0).LessThan(40);
        }
    }
}

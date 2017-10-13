using FluentValidation;

namespace LP.UserProfile.Domain.User_Area.Core.Validators
{
    internal sealed class LoginValidator : AbstractValidator<string>
    {
        public LoginValidator()
        {
            RuleFor(login => login).NotEmpty();
            RuleFor(login => login.Length).InclusiveBetween(5, 50);
        }
    }
}

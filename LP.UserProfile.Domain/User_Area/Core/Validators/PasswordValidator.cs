using FluentValidation;

namespace LP.UserProfile.Domain.User_Area.Core.Validators
{
    internal sealed class PasswordValidator : AbstractValidator<string>
    {
        public PasswordValidator()
        {
            RuleFor(password => password).NotEmpty();
            RuleFor(password => password)
              .Matches("[A-Z]").WithMessage("Password must containt Upper case letters")
              .Matches("[a-z]").WithMessage("Password must containt Lower case letters")
              .Matches("[0-9]").WithMessage("Password must containt Digits");
            RuleFor(password => password.Length).InclusiveBetween(5, 20);
        }
    }
}

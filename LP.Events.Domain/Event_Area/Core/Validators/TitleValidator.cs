using FluentValidation;

namespace LP.Events.Domain.Event_Area.Core.Validators
{
    internal sealed class TitleValidator : AbstractValidator<string>
    {
        public TitleValidator()
        {
            RuleFor(title => title).NotNull();
            RuleFor(title => title).NotEmpty();
            RuleFor(title => title.Length).GreaterThan(0);
            RuleFor(title => title.Length).LessThan(80);
        }
    }
}

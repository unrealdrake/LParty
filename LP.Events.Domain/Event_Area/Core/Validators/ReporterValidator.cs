using FluentValidation;

namespace LP.Events.Domain.Event_Area.Core.Validators
{
    internal sealed class ReporterValidator : AbstractValidator<int>
    {
        public ReporterValidator()
        {
            RuleFor(reporterId => reporterId).GreaterThan(0);
        }
    }
}

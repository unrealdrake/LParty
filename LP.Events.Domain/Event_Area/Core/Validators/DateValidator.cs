using System;
using FluentValidation;

namespace LP.Events.Domain.Event_Area.Core.Validators
{
    internal sealed class DateValidator : AbstractValidator<DateTime>
    {
        public DateValidator()
        {
            RuleFor(eventDate => eventDate).Must(evDate => evDate > DateTime.UtcNow).WithMessage("Event date can not be earlier than now");
        }
    }
}

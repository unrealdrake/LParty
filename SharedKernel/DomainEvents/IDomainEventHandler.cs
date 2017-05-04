using System;

namespace Core.SharedKernel.DomainEvents
{
    public interface IDomainEventHandler
    {
        void Handle(EventArgs eventArgs);
    }
}

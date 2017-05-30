using System;

namespace SharedKernel.DomainEvents
{
    public interface IDomainEventHandler
    {
        void Handle(EventArgs eventArgs);
    }
}

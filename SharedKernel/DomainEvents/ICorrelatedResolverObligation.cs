using System.Collections.Generic;

namespace SharedKernel.DomainEvents
{
    public interface ICorrelatedResolverObligation
    {
        IEnumerable<IHandles<T>> ResolveAll<T>() where T : IDomainEvent;
    }
}

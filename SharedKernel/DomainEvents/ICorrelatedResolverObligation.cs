using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.DomainEvents
{
    public interface ICorrelatedResolverObligation
    {
        IEnumerable<IHandles<T>> ResolveAll<T>() where T : IDomainEvent;
    }
}

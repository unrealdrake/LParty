using System;
using System.Collections.Generic;

namespace SharedKernel.DomainEvents
{
    public sealed class DomainEventMediator
    {
        private static readonly Lazy<DomainEventMediator> _instance = new Lazy<DomainEventMediator>(() => new DomainEventMediator());
        public static DomainEventMediator SingleInstance => _instance.Value;
        private DomainEventMediator() { }

        private static List<IDomainEventHandler> _domainEventHandlers = new List<IDomainEventHandler>();

        public static void RegisterDomainEventHandler(IDomainEventHandler handler)
        {
            _domainEventHandlers.Add(handler);
        }
        public static void RaiseEvent(EventArgs eventArgs)
        {
            foreach (var handler in _domainEventHandlers)
            {
                handler.Handle(eventArgs);
            }
        }
    }
}

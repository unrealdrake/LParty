using System;
using System.Collections.Generic;

namespace SharedKernel.DomainEvents
{
    public sealed class DomainEventMediator
    {
        private static readonly Lazy<DomainEventMediator> _instance = new Lazy<DomainEventMediator>(() => new DomainEventMediator());
        public static DomainEventMediator SingleInstance => _instance.Value;
        private DomainEventMediator() { }

        private static readonly List<IDomainEventHandler> DomainEventHandlers = new List<IDomainEventHandler>();

        public static void RegisterDomainEventHandler(IDomainEventHandler handler)
        {
            DomainEventHandlers.Add(handler);
        }
        public static void RaiseEvent(EventArgs eventArgs)
        {
            foreach (var handler in DomainEventHandlers)
            {
                handler.Handle(eventArgs);
            }
        }
    }
}

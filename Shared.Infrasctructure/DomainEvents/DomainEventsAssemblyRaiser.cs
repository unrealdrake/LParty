using System;
using System.Collections.Generic;
using SharedKernel.DomainEvents;

namespace Shared.Infrasctructure.DomainEvents
{
    public class DomainEventsAssemblyRaiser : IDomainEventsRaiser
    {
        public DomainEventsAssemblyRaiser(ICorrelatedResolverObligation obligatedResolver)
        {
            ObligatedResolver = obligatedResolver;
        }

        public static ICorrelatedResolverObligation ObligatedResolver;
        
        public List<Delegate> Actions { get; set; }

        //Registers a callback for the given domain event
        public void Register<T>(Action<T> callback) where T : IDomainEvent
        {
            if (Actions == null)
                Actions = new List<Delegate>();

            Actions.Add(callback);
        }

        //Clears callbacks passed to Register on the current thread
        public void ClearCallbacks()
        {
            Actions = null;
        }

        //Raises the given domain event
        public void Raise<T>(T args) where T : IDomainEvent
        {
            IEnumerable<IHandles<T>> handlers = ObligatedResolver.ResolveAll<T>();
            foreach (var handler in handlers)
                handler.Handle(args);

            if (Actions != null)
                foreach (var action in Actions)
                    if (action is Action<T>)
                        ((Action<T>)action)(args);
        }
    }
}

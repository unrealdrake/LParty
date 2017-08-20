using System;
using System.Collections.Generic;

namespace SharedKernel.DomainEvents
{
    public interface IDomainEventsRaiser
    {
        List<Delegate> Actions { get; set; }
        //Registers a callback for the given domain event
        void Register<T>(Action<T> callback) where T : IDomainEvent;
        //Clears callbacks passed to Register on the current thread
        void ClearCallbacks();
        //Raises the given domain event
        void Raise<T>(T args) where T : IDomainEvent;
    }
}

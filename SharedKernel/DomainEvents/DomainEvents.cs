using System;

namespace SharedKernel.DomainEvents
{
    public static class DomainEvents
    {
        private static IDomainEventsRaiser _eventsRaiser;

        public static void SetResolver(IDomainEventsRaiser raiser)
        {
            _eventsRaiser = raiser;
        }

        //Registers a callback for the given domain event
        public static void Register<T>(Action<T> callback) where T : IDomainEvent
        {
            _eventsRaiser.Register(callback);
        }

        //Clears callbacks passed to Register on the current thread
        public static void ClearCallbacks()
        {
            _eventsRaiser.ClearCallbacks();
        }

        //Raises the given domain event
        public static void Raise<T>(T args) where T : IDomainEvent
        {
            _eventsRaiser.Raise(args);
        }
    }
}

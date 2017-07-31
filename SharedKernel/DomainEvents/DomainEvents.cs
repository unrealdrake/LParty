﻿using System;
using System.Collections.Generic;

namespace SharedKernel.DomainEvents
{
    public static class DomainEvents
    {
        public static ICorrelatedResolverObligation ObligatedResolver;

        [ThreadStatic] //so that each thread has its own callbacks
        private static List<Delegate> _actions;


        //Registers a callback for the given domain event
        public static void Register<T>(Action<T> callback) where T : IDomainEvent
        {
            if (_actions == null)
                _actions = new List<Delegate>();

            _actions.Add(callback);
        }

        //Clears callbacks passed to Register on the current thread
        public static void ClearCallbacks()
        {
            _actions = null;
        }

        //Raises the given domain event
        public static void Raise<T>(T args) where T : IDomainEvent
        {
            IEnumerable<IHandles<T>> handlers = ObligatedResolver.ResolveAll<T>();
            foreach (var handler in handlers)
                handler.Handle(args);

            if (_actions != null)
                foreach (var action in _actions)
                    if (action is Action<T>)
                        ((Action<T>)action)(args);
        }
    }
}


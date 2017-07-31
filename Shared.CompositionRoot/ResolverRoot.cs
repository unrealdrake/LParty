using System.Collections.Generic;
using SharedKernel.DomainEvents;

namespace Shared.CompositionRoot
{
    public class ResolverRoot
    {
        private static readonly DependenciesRegistrator Resolver;
        public static SettingsForDependencies Settings { }
        static ResolverRoot()
        {
            Settings = DependenciesRegistrator.Settings;
            Resolver = new DependenciesRegistrator();
            DomainEvents.ObligatedResolver = Resolver;
        }

        public static T Resolve<T>()
        {
            return Resolver.Resolve<T>();
        }

        public IEnumerable<IHandles<T>> ResolveAll<T>() where T : IDomainEvent
        {
            return Resolver.ResolveAll<T>();
        }
    }
}

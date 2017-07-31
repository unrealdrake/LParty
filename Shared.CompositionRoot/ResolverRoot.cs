using System.Collections.Generic;
using SharedKernel.DomainEvents;

namespace Shared.CompositionRoot
{
    public class ResolverRoot
    {
        private static readonly DependenciesRegistrator Resolver;

        public static SettingsForDependencies Settings
        {
            get => DependenciesRegistrator.Settings;
            set => DependenciesRegistrator.Settings = value;
        }

        static ResolverRoot()
        {
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

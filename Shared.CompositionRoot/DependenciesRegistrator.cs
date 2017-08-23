using System.Collections.Generic;
using SharedKernel.DomainEvents;
using StructureMap;

namespace Shared.CompositionRoot
{
    public class DependenciesRegistrator : ICorrelatedResolverObligation
    {
        public static SettingsForDependencies Settings = new SettingsForDependencies();

        private static readonly Container Container = Register();

        public T Resolve<T>()
        {
            return Container.GetInstance<T>();
        }

        public static Container Register(Registry registryToExtend = null)
        {
            registryToExtend?.IncludeRegistry<RootRegistry>();
            var container = new Container(cfg =>
            {
                cfg.AddRegistry<RootRegistry>();
            });
            ResolverRoot.Init();
            return container;
        }

        public IEnumerable<IHandles<T>> ResolveAll<T>() where T : IDomainEvent
        {
            return Container.GetAllInstances<IHandles<T>>();
        }
    }
}

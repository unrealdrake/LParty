using System.Collections.Generic;
using LP.UserProfile.Domain.User_Area.Repositories;
using LP.UserProfile.EFRepository;
using SharedKernel.DomainEvents;
using StructureMap;

namespace Shared.CompositionRoot
{
    internal class DependenciesRegistrator : ICorrelatedResolverObligation
    {
        public static SettingsForDependencies Settings = new SettingsForDependencies();

        private static readonly Container Container = Register();

        public T Resolve<T>()
        {
            return Container.GetInstance<T>();
        }

        public static Container Register()
        {
            var container = new Container(cfg =>
            {
                MediatorBuilder.RegisterDependenciesForMediator(cfg);

                cfg.For<IReadUserProfileRepository>().Use<ReadUserProfileRepository>().Transient();
                cfg.For<IWriteUserProfileRepository>().Use<WriteUserProfileRepository>().Transient();
                cfg.For<UserProfileEFContext>().Use(ctx => new UserProfileEFContext(Settings.ConnectionString));
            });

            return container;
        }

        public IEnumerable<IHandles<T>> ResolveAll<T>() where T : IDomainEvent
        {
            return Container.GetAllInstances<IHandles<T>>();
        }
    }
}

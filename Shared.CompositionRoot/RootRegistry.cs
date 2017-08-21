using LP.UserProfile.Domain.User_Area.Repositories;
using LP.UserProfile.EFRepository;
using Shared.Infrasctructure.DomainEvents;
using SharedKernel.DomainEvents;
using StructureMap;

namespace Shared.CompositionRoot
{
    public class RootRegistry : Registry
    {
        public static SettingsForDependencies Settings = new SettingsForDependencies();

        public RootRegistry()
        {
            MediatorBuilder.RegisterDependenciesForMediator(this);

            For<IReadUserProfileRepository>().Use<ReadUserProfileRepository>().Transient();
            For<IWriteUserProfileRepository>().Use<WriteUserProfileRepository>().Transient();

            For<UserProfileEFContext>().Use(ctx => new UserProfileEFContext(Settings.ConnectionString));

            For<ICorrelatedResolverObligation>().Use<DependenciesRegistrator>();

            For<IDomainEventsRaiser>().Use<DomainEventsAssemblyRaiser>();
        ;
        }
    }
}

using LP.UserProfile.EFRepository;
using LP.UserProfile.Repository;
using StructureMap;

namespace Shared.CompositionRoot
{
    public class DependenciesRegistrator
    {
        public static SettingsForDependencies Settings = new SettingsForDependencies();

        private static readonly Container Container = Register();

        public static T Resolve<T>()
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
    }
}

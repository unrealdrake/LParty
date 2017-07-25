using LP.UserProfile.EFRepository;
using LP.UserProfile.Repository;
using StructureMap;

namespace Shared.CompositionRoot
{
    public class DependenciesRegistrator
    {
        private static Container _container = Register();

        public static Container Container()
        {
            if (_container == null)
            {
                _container = Register();
            }

            return _container;
        }

        public static Container Register()
        {
            var container = new Container(cfg =>
            {
                MediatorBuilder.RegisterDependenciesForMediator(cfg);

                cfg.For<IReadUserProfileRepository>().Use<ReadUserProfileRepository>();
                cfg.For<IWriteUserProfileRepository>().Use<WriteUserProfileRepository>();
            });

            return container;
        }
    }
}

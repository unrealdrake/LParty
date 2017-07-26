using Shared.CompositionRoot;
using Shared.Infrasctructure.EntityFramework;

namespace LP.UserProfile.Tests.Shared
{
    public abstract class BaseTestClass
    {
        protected static void SetTestSettings()
        {
            DependenciesRegistrator.Settings.ConnectionString = ConnectionStringFactory.Create(useTestConnectionString: true);
        }
    }
}

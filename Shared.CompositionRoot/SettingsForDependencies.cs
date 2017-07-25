using Shared.Infrasctructure.EntityFramework;

namespace Shared.CompositionRoot
{
    public class SettingsForDependencies
    {
        public SettingsForDependencies()
        {
            ConnectionString = ConnectionStringFactory.Create();
        }

        public string ConnectionString { get; set; }
    }
}

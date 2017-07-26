using Microsoft.Extensions.Configuration;

namespace Shared.Config
{
    internal sealed class ConfigInitializer
    {
        private const string SettingsFileName = "settings.json";
        public static IConfigurationRoot Configuration { get; }

        static ConfigInitializer()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .AddJsonFile(SettingsFileName,
                    optional: true,
                    reloadOnChange: true);
            Configuration = builder.Build();
        }
    }
}

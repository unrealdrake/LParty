
namespace Shared.Config
{
    public sealed class Config
    {
        public static string ConnectionString_LP => ConfigInitializer.Configuration["connectionStrings:LP"];
        public static string ConnectionString_LP_Testing => ConfigInitializer.Configuration["connectionStrings:LP_Testing"];
        public static string UserProfilesApi => ConfigInitializer.Configuration["systemApiUrls:UserProfilesApi"];
    }
}


namespace Shared.Config
{
    public sealed class Config
    {
        public static string ConnectionString_LP => ConfigInitializer.Configuration["connectionStrings:LP"];
    }
}

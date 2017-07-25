namespace Shared.Infrasctructure.EntityFramework
{
    public class ConnectionStringFactory
    {
        public static string Create(bool useTestConnectionString = false)
        {
            return useTestConnectionString
                ? Config.Config.ConnectionString_LP_Testing
                : Config.Config.ConnectionString_LP;
        }
    }
}

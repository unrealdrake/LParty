using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Shared.Gateway;

namespace LP.EventSystem.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args).
                UseStartup<Startup>().
                Build();
    }
}

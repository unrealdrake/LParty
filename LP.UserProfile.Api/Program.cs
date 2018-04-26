using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Shared.Gateway;

namespace LP.UserProfile.Api
{
    /// <summary>
    /// Main Application point
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Application Entry
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        /// <summary>
        /// Building Web host
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args).
                UseStartup<Startup>().
                Build();
    }
}

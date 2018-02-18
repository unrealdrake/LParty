﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.CompositionRoot;
using Shared.Gateway;
using StructureMap;

namespace LP.UserProfile.Api
{
    /// <summary>
    /// Startup configuration class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Startup constructor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Services configuring
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            StartupConfig.ConfigureServices(services);
        }

        /// <summary>
        /// Container configuring
        /// </summary>
        /// <param name="registry"></param>
        public void ConfigureContainer(Registry registry)
        {
            DependenciesRegistrator.Register(registry);
        }

        /// <summary>
        /// General configuring
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            StartupConfig.ConfigureApp(app, env);
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller}/{action}/{id?}");
            });
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.CompositionRoot;
using Shared.Gateway;
using StructureMap;

namespace LP.EventSystem.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

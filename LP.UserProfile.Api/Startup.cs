using System.IO;
using LP.UserProfile.Api.Middlewares.ErrorHandling;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Shared.CompositionRoot;
using StructureMap;
using Swashbuckle.AspNetCore.Swagger;

namespace LP.UserProfile.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSwaggerGen(gen =>
            {
                gen.SwaggerDoc("v1", new Info {Title = "User Profile API", Version = "1"});
                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "LP.UserProfile.Api.xml");
                gen.IncludeXmlComments(filePath);
            });
        }

        public void ConfigureContainer(Registry registry)
        {
            DependenciesRegistrator.Register(registry);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "User Profile API V1");
            });
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller}/{action}/{id?}");
            });

        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Autofac;
using System.Reflection;
using Ollix.Infrastructure.IoC.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Ollix.Infrastructure.IoC.Installers.Api;

namespace Ollix.Infrastructure.IoC
{
    public static class NativeInjector
    {    
        public static IServiceCollection InstallServices(this IServiceCollection services, IConfiguration configuration, params Assembly[] assemblies)
        {
            IEnumerable<IServiceInstaller> servicesInstallers = assemblies
                .SelectMany(a => a.DefinedTypes)
                .Where(typeInfo => typeof(IServiceInstaller).IsAssignableFrom(typeInfo) &&
                    !typeInfo.IsInterface &&
                    !typeInfo.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IServiceInstaller>();


            foreach (IServiceInstaller serviceInstaller in servicesInstallers)
            {
                serviceInstaller.Install(services, configuration);
            }

            return services;
        }

        public static WebApplication UseServices(this WebApplication app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
            //app.UseAuthentication();
            //app.UseAuthorization();
            //app.UseCors(builder => builder
            //    .SetIsOriginAllowed(orign => true)
            //    .AllowAnyMethod()
            //    .AllowAnyHeader()
            //    .AllowCredentials());
            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));

            app.MapControllers();

            return app;
        }
    }
}

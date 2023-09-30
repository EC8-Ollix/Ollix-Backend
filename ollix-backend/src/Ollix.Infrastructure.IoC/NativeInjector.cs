using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ollix.Infrastructure.IoC.Configs;
using Ollix.Infrastructure.IoC.Extensions;
using Ollix.Infrastructure.IoC.Interfaces;
using System.Reflection;

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

        public static WebApplication UseServices(this WebApplication app, IWebHostEnvironment env, IConfiguration configuration)
        {
            app.UseHttpsRedirection();
            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
            //app.UseCors(builder => builder
            //    .SetIsOriginAllowed(orign => true)
            //    .AllowAnyMethod()
            //    .AllowAnyHeader()
            //    .AllowCredentials());
            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", configuration.GetApiName()));

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}

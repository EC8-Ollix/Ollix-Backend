using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ollix.Infrastructure.Data.Repositories;
using Ollix.Infrastructure.IoC.Interfaces;
using Ollix.SharedKernel;
using Ollix.SharedKernel.Interfaces;

namespace Ollix.Infrastructure.IoC.Installers
{
    public class SharedKernelServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            var applicationAssembly = typeof(Application.AssemblyReference).Assembly;
            var sharedAssembly = typeof(SharedKernel.AssemblyReference).Assembly;
            var domainAssembly = typeof(Domain.AssemblyReference).Assembly;

            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));

            services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();

            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblies(domainAssembly, applicationAssembly, sharedAssembly));
        }
    }
}

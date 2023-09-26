using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ollix.Infrastructure.IoC.Interfaces;
using Ollix.SharedKernel.Interfaces;
using Ollix.SharedKernel;
using System.Reflection;

namespace Ollix.Infrastructure.IoC.Installers
{
    public class SharedKernelServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            var applicationAssembly = typeof(Application.AssemblyReference).Assembly;
            var sharedAssembly = typeof(SharedKernel.AssemblyReference).Assembly;

            //services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            //services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));

            services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();

            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblies(applicationAssembly, sharedAssembly));
        }
    }
}

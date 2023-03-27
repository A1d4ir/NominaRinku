using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NominaRinku.Infrastructure.Persistence;
using NominaRinku.Infrastructure.Repositories;
using NominaRinlu.Application.Contracts.Persistense;

namespace NominaRinku.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<NominaRinkuDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

            services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
            services.AddScoped<ISueldoRepository, SueldoReporitory>();

            return services;
        }
    }
}

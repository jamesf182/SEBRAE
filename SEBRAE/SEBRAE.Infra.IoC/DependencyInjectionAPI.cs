using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SEBRAE.Application.Interfaces;
using SEBRAE.Application.Mappings;
using SEBRAE.Application.Services;
using SEBRAE.Domain.Interfaces;
using SEBRAE.Infra.Data.Context;
using SEBRAE.Infra.Data.Repositories;

namespace SEBRAE.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IContaRepository, ContaRepository>();

            services.AddScoped<IContaService, ContaService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}

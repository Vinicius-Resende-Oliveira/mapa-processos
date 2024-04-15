using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MP.Domain.Interfaces;
using MP.Domain.Interfaces.Repository;
using MP.Infra.Data;
using MP.Infra.Data.Repository;

namespace MP.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MapaProcessosDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProcessoRepository, ProcessoRespository>();

            return services;
        }
    }
}

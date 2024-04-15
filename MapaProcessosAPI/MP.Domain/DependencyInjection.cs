using Microsoft.Extensions.DependencyInjection;
using MP.Domain.Interfaces.Services;
using MP.Domain.Services;

namespace MP.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddTransient<IProcessosService, ProcessosService>();

            return services;
        }
    }
}

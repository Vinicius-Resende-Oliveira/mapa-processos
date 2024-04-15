using Microsoft.Extensions.DependencyInjection;
using MP.Application.Interfaces;
using MP.Application.OpenApp;
using System.Reflection;

namespace MP.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IProcessoOpenApp, ProcessoOpenApp>();

            return services;
        }
    }
}

using CleanArchitecture.Application.Interface.Persistence;
using CleanArchitecture.Persistence.Contexts;
using CleanArchitecture.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInjectionPersistence(this IServiceCollection services)
        {
            services.AddSingleton<DapperContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}

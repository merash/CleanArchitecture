using CleanArchitecture.Application.Interface.Persistence;
using CleanArchitecture.Persistence.Contexts;
using CleanArchitecture.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInjectionPersistence(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<Context>();
            serviceCollection.AddScoped<IProductRepository, ProductRepository>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            return serviceCollection;
        }
    }
}

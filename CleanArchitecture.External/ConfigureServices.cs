using CleanArchitecture.Application.Interface.External;
using CleanArchitecture.External.Contexts;
using CleanArchitecture.External.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.External
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInjectionExternal(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<RestSharpContext>();
            serviceCollection.AddScoped<IDiscountRepository, DiscountRepository>();

            return serviceCollection;
        }
    }
}

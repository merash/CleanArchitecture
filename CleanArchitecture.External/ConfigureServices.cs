using CleanArchitecture.Application.Interface.External;
using CleanArchitecture.External.Contexts;
using CleanArchitecture.External.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.External
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInjectionExternal(this IServiceCollection services)
        {
            services.AddSingleton<RestSharpContext>();
            services.AddScoped<IDiscountRepository, DiscountRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}

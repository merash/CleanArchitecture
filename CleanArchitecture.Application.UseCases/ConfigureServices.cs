using CleanArchitecture.Application.UseCases.Commons.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitecture.Application.UseCases
{
    public static class ConfigureServices
    {
        public static void AddInjectionApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
            serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            serviceCollection.AddMemoryCache();

            serviceCollection.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggerBehaviour<,>));
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        }
    }
}

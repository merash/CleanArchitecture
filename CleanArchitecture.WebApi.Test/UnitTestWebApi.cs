using CleanArchitecture.Application.UseCases.Products.Queries.GetByProductIdQuery;
using CleanArchitecture.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.WebApi.Test
{
    public class UnitTestWebApi
    {
        [Fact]
        public void GetById_Returns_OkResult()
        {
            var serviceCollection = new ServiceCollection();

            var serviceProvider = serviceCollection
                .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetByProductIdHandler).Assembly))
                .BuildServiceProvider();

            var mediator = serviceProvider.GetRequiredService<IMediator>();

            var controller = new ProductController(mediator);
            var result = controller.GetById(1);

            Assert.IsType<OkObjectResult>(result);
        }
    }
}
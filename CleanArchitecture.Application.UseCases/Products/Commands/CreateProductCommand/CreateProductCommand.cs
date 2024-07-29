using CleanArchitecture.Application.UseCases.Commons.Bases;
using MediatR;

namespace CleanArchitecture.Application.UseCases.Products.Commands.CreateProductCommand
{
    public class CreateProductCommand : IRequest<BaseResponse<bool>>
    {
        public required string Name { get; set; }
        public int Status { get; set; }
        public int Stock { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
    }
}

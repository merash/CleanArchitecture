using CleanArchitecture.Application.UseCases.Commons.Bases;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.UseCases.Products.Queries.GetProductsQuery
{
    public class GetProductsQuery : IRequest<BaseResponse<List<Product>>>
    {
    }
}

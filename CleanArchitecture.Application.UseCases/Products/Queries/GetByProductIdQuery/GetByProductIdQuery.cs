using CleanArchitecture.Application.Dto;
using CleanArchitecture.Application.UseCases.Commons.Bases;
using MediatR;

namespace CleanArchitecture.Application.UseCases.Products.Queries.GetByProductIdQuery
{
    public class GetByProductIdQuery : IRequest<BaseResponse<ProductDto>>
    {
        public long ProductId { get; set; }
    }
}

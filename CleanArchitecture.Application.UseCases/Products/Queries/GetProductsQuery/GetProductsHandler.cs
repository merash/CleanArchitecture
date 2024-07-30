using CleanArchitecture.Application.Interface.Persistence;
using CleanArchitecture.Application.UseCases.Commons.Bases;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.UseCases.Products.Queries.GetProductsQuery
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, BaseResponse<List<Product>>>
    {
        readonly IUnitOfWork unitOfWork;

        public GetProductsHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public Task<BaseResponse<List<Product>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<List<Product>>();
            try
            {
                var products = this.unitOfWork.Products.Get();
                if (products is not null)
                {
                    response.Data = products;
                    response.succcess = true;
                    response.Message = "Query succeed!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return Task.FromResult(response);
        }
    }
}

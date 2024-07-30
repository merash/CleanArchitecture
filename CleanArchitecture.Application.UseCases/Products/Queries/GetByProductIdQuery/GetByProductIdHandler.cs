using AutoMapper;
using CleanArchitecture.Application.Dto;
using CleanArchitecture.Application.Interface.External;
using CleanArchitecture.Application.Interface.Persistence;
using CleanArchitecture.Application.UseCases.Commons.Bases;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace CleanArchitecture.Application.UseCases.Products.Queries.GetByProductIdQuery
{
    public class GetByProductIdHandler : IRequestHandler<GetByProductIdQuery, BaseResponse<ProductDto>>
    {
        readonly IUnitOfWork unitOfWork;
        readonly IDiscountRepository discountRepository;
        readonly IMapper mapper;
        readonly IMemoryCache memoryCache;

        public GetByProductIdHandler(IUnitOfWork unitOfWork, IDiscountRepository discountRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.discountRepository = discountRepository ?? throw new ArgumentNullException(nameof(discountRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));

            this.memoryCache.Set("Status", new Dictionary<int, string> { { 1, "Active" }, { 0, "Inactive" } }, new MemoryCacheEntryOptions { SlidingExpiration = TimeSpan.FromMinutes(5) });
        }

        public Task<BaseResponse<ProductDto>> Handle(GetByProductIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<ProductDto>();
            try
            {
                var product = this.unitOfWork.Products.Get(request.ProductId);
                if (product is not null)
                {
                    response.Data = this.mapper.Map<ProductDto>(product);

                    this.memoryCache.TryGetValue("Status", out Dictionary<int, string>? status);
                    response.Data.StatusName = status?[product.Status];

                    response.Data.Discount = this.discountRepository.GetDiscount();
                    response.Data.FinalPrice = response.Data.Price * (100 - response.Data.Discount) / 100;
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
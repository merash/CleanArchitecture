using AutoMapper;
using CleanArchitecture.Application.Dto;
using CleanArchitecture.Application.UseCases.Commons.Bases;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace CleanArchitecture.Application.UseCases.Products.Queries.GetByProductIdQuery
{
    public class GetByProductIdHandler : IRequestHandler<GetByProductIdQuery, BaseResponse<ProductDto>>
    {
        private readonly Interface.Persistence.IUnitOfWork _unitOfWorkPersistence;
        private readonly Interface.External.IUnitOfWork _unitOfWorkExternal;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public GetByProductIdHandler(Interface.Persistence.IUnitOfWork unitOfWorkPersistence, Interface.External.IUnitOfWork unitOfWorkExternal, IMapper mapper, IMemoryCache memoryCache)
        {
            _unitOfWorkPersistence = unitOfWorkPersistence ?? throw new ArgumentNullException(nameof(unitOfWorkPersistence));
            _unitOfWorkExternal = unitOfWorkExternal ?? throw new ArgumentNullException(nameof(unitOfWorkExternal));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));

            _memoryCache.Set("Status", new Dictionary<int, string> { { 1, "Active" }, { 0, "Inactive" } }, new MemoryCacheEntryOptions { SlidingExpiration = TimeSpan.FromMinutes(5) });
        }

        public async Task<BaseResponse<ProductDto>> Handle(GetByProductIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<ProductDto>();
            try
            {
                var product = _unitOfWorkPersistence.Products.Get(request.ProductId);
                if (product is not null)
                {
                    response.Data = _mapper.Map<ProductDto>(product);

                    _memoryCache.TryGetValue("Status", out Dictionary<int, string> status);
                    response.Data.StatusName = status[product.Status];

                    response.Data.Discount = _unitOfWorkExternal.Discounts.Get().discount;
                    response.Data.FinalPrice = response.Data.Price * (100 - response.Data.Discount) / 100;
                    response.succcess = true;
                    response.Message = "Query succeed!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
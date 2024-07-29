using AutoMapper;
using CleanArchitecture.Application.Interface.Persistence;
using CleanArchitecture.Application.UseCases.Commons.Bases;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.UseCases.Products.Commands.UpdateProductCommand
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BaseResponse<bool>> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var product = _mapper.Map<Product>(command);
                response.Data = _unitOfWork.Products.Update(product);
                if (response.Data)
                {
                    response.succcess = true;
                    response.Message = "Update succeed!";
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
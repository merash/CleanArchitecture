using AutoMapper;
using CleanArchitecture.Application.Interface.Persistence;
using CleanArchitecture.Application.UseCases.Commons.Bases;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.UseCases.Products.Commands.CreateProductCommand
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, BaseResponse<bool>>
    {
        readonly IUnitOfWork unitOfWork;
        readonly IMapper mapper;

        public CreateProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<BaseResponse<bool>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var product = this.mapper.Map<Product>(command);
                response.Data = this.unitOfWork.Products.Insert(product);
                if (response.Data)
                {
                    response.succcess = true;
                    response.Message = "Create succeed!";
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
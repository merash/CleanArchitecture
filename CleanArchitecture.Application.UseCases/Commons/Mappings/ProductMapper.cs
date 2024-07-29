using AutoMapper;
using CleanArchitecture.Application.Dto;
using CleanArchitecture.Application.UseCases.Products.Commands.CreateProductCommand;
using CleanArchitecture.Application.UseCases.Products.Commands.UpdateProductCommand;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.UseCases.Commons.Mappings
{
    public class ProductMapper: Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}

using AutoMapper;
using Marketplace.Application.Models.Product;
using Marketplace.Core.Entities;

namespace Marketplace.Application.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, CreateProductModel>();
            CreateMap<CreateProductModel, Product>();
            CreateMap<Product, ProductModel>();
            CreateMap<ProductModel, Product>();
            CreateMap<Product, UpdateProductModel>();
            CreateMap<UpdateProductModel, Product>();
        }
    }
}

using AutoMapper;
using MicroserviceAralik.Catalog.Dtos.BrandDtos;
using MicroserviceAralik.Catalog.Dtos.CategoryDtos;
using MicroserviceAralik.Catalog.Dtos.ProductDetailDtos;
using MicroserviceAralik.Catalog.Dtos.ProductDtos;
using MicroserviceAralik.Catalog.Entities;

namespace MicroserviceAralik.Catalog.Mappings;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Brand, CreateBrandDto>().ReverseMap();
        CreateMap<Brand, UpdateBrandDto>().ReverseMap();
        CreateMap<Brand, ResultBrandDto>().ReverseMap();

        CreateMap<Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        CreateMap<Category, ResultCategoryDto>().ReverseMap();

        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<Product, UpdateProductDto>().ReverseMap();
        CreateMap<Product, ResultProductDto>().ReverseMap();

        CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
        CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
        CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();


    }
}

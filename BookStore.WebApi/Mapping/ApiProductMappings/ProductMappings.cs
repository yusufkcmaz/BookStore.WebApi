using AutoMapper;
using BookStore.EntityLayer.Concrete;
using BookStore.WebApi.Dtos.ApiProductDto;
using System.Drawing.Printing;

namespace BookStore.WebApi.Mapping.ApiProductMappings
{
    public class ProductMappings : Profile
    {
        public ProductMappings()
        {
            CreateMap<Product, CreateProductDto>()
                  .ForMember(dest => dest.ProductImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
            .ReverseMap();

                                
            CreateMap<Product, ResulProductDto>().ReverseMap();


            CreateMap<Product, ResultProductDetailDto>()
                  .ForMember(dest => dest.WriterName, opt => opt.MapFrom(src => src.Writer != null ? src.Writer.Name : "Unknown"))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.CategoryName : "No Category"))
            .ReverseMap();

            CreateMap<Product , UpdateProductDto>()
                .ReverseMap();

            CreateMap<Product, RandomProductDto>().ReverseMap();

        }

    }
}

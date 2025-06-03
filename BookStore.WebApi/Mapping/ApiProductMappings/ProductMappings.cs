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
            CreateMap<Product, CreateProductDto>().ReverseMap();
            //      .ForMember(dest => dest.ProductImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
            //.ReverseMap();


            CreateMap<Product, ResulProductDto>().ReverseMap();


            CreateMap<Product, ResultProductDetailDto>()
     .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
     .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName)) // Tek seferde doğru eşleme
     .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.ProductPrice))
     .ForMember(dest => dest.ProductImageUrl, opt => opt.MapFrom(src => src.ProductImageUrl))
     .ForMember(dest => dest.ProductWriterName, opt => opt.MapFrom(src => src.ProductWriterName))


            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName)).ReverseMap();


            CreateMap<Product, UpdateProductDto>()
                .ReverseMap();

            CreateMap<Product, RandomProductDto>().ReverseMap();

        }

    }
}

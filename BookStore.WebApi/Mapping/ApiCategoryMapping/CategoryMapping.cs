using AutoMapper;
using BookStore.EntityLayer.Concrete;
using BookStore.WebApi.Dtos.ApiCategoryDto;

namespace BookStore.WebApi.Mapping.ApiCategoryMapping
{
    public class CategoryMapping :Profile
    {
        public CategoryMapping()
        {
            CreateMap<Product ,ResultCategoryDto >().ReverseMap();
            CreateMap<Category , CreateCategoryDto>().ReverseMap();
            CreateMap<Category , UpdateCategoryDto>().ReverseMap();
        }
    }
}

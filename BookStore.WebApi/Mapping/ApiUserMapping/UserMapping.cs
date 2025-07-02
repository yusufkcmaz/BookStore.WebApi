using AutoMapper;
using BookStore.EntityLayer.Concrete;
using BookStore.WebApi.Dtos.ApiUserDto;

namespace BookStore.WebApi.Mapping.ApiUserMapping
{
    public class UserMapping : Profile

    {
        public UserMapping()
        {
            CreateMap<AppUser , UserDto>().ReverseMap();
        }

    }
}

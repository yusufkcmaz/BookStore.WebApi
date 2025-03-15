using AutoMapper;
using BookStore.EntityLayer.Concrete;
using BookStore.WebApi.Dtos.ApiWriterDto;

namespace BookStore.WebApi.Mapping.ApiWriterMappings
{
    public class WriterMapping:  Profile

    {
        public WriterMapping()
        {
            CreateMap<Writer , CreateWriterDto>().ReverseMap();
            CreateMap<Writer , UpdateWriterDto>().ReverseMap();
        }
    }
}

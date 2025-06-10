using AutoMapper;
using BookStore.EntityLayer.Concrete;
using BookStore.WebApi.Dtos.SubscribeDtos;

namespace BookStore.WebApi.Mapping.ApiSubscribeMapping
{
    public class SubscribeMapping : Profile
    {
        public SubscribeMapping()
        {
            CreateMap<Subscribe , ResultSubscribeDto>().ReverseMap();
        }
    }
}

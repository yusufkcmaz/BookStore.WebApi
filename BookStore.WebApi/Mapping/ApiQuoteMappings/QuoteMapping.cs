using AutoMapper;
using BookStore.EntityLayer.Concrete;
using BookStore.WebApi.Dtos.ApiQuoteDto;

namespace BookStore.WebApi.Mapping.ApiQuoteMappings
{
    public class QuoteMapping :Profile
    {
       public QuoteMapping()
        {
            CreateMap<Quote , RandomQuoteDto>().ReverseMap();
        }

    }
}

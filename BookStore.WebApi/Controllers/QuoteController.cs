using AutoMapper;
using BookStore.BusinessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using BookStore.WebApi.Dtos.ApiProductDto;
using BookStore.WebApi.Dtos.ApiQuoteDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
       
        private readonly IQuoteService _quoteService;
        private readonly IMapper _mapper;

        public QuoteController(
            
            IQuoteService quoteService,
            IMapper mapper)
        {
            _quoteService = quoteService;
           
            _mapper = mapper;
        }

        [HttpGet]

        public IActionResult QuoteList()
        {
            var values = 
            _quoteService.TGetAll();
            return Ok(values);
        }

        [HttpGet("ALLQuote")]
        public IActionResult QuoteAll(int id)
        {
            var values = 
            _quoteService.TGetById(id); 
            return Ok(values);    
        }

        [HttpGet("RandomQuote")]
        public IActionResult GetRandomQuote(RandomQuoteDto quoteDto)
        {
                                                
           var quote = _quoteService.TGetRandomQuote();
            if (quote == null)
            {
                return NotFound("Bugün Alıntı yok :) ");
            }
            var dto = _mapper.Map<RandomQuoteDto>(quote);
               
            return Ok(dto);
        }

        [HttpPut]
        public IActionResult PutQuote(Quote quote)
        {
            _quoteService.TUpdate(quote);
            return Ok("Güncelleme başarılı");    


        }


        [HttpDelete]
        public IActionResult DeleteQuote(int id)
        {
            _quoteService.TDelete(id);
            return Ok("Silindi");
        }

        [HttpPost]
        public IActionResult CreateQuote(Quote quote)
        {
            _quoteService.TAdd(quote);
            return Ok("Eklendiii");
        }

    }    //Quote TGetRandomQuote();
        //List<Quote> TGetAllQuotes();
    }

using AutoMapper;
using BookStore.BusinessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;
        private readonly IMapper _mapper;

        public SubscribeController(ISubscribeService subscribeService, IMapper mapper)
        {
            _subscribeService = subscribeService;
            _mapper = mapper;
        }

        [HttpPost("addsubscribe")]
        public IActionResult AddSubscribe([FromForm] string Mail)
        {
            if (string.IsNullOrWhiteSpace(Mail) || !Mail.Contains("@"))
            {
                return BadRequest("Lütfen geçerli bir e-posta giriniz");
            }

            var exists = _subscribeService.TGetAll().Any(x => x.Mail == Mail);
            if (exists)
            {
                return Conflict("Bu e-posta zaten kayıtlı");
            }

            var subscribe = new Subscribe { Mail = Mail };
            _subscribeService.TAdd(subscribe);

            return Ok("Abonelik başarılı");
        }
    }


}

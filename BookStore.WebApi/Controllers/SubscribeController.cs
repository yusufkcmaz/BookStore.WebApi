using AutoMapper;
using BookStore.BusinessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;
        private readonly IMapper _mapper;

       private readonly string smtpHost = "smtp.gmail.com";
        private readonly int smtpPort = 587;
        private readonly string smtpUser = "Bookstore@gmail.com";
        private readonly string smtpPass = "ubitjxmdyzxyyylz";


        public SubscribeController(ISubscribeService subscribeService, IMapper mapper)
        {
            _subscribeService = subscribeService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SubscribeList()
        {
            var result = _subscribeService.TGetAll();
            return Ok(result);
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

            try
            {
                SendMail(Mail);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Abonelik başarılı ama mail gönderilemedi: " + ex.Message);
            }

            //_emailsender.SendEmail(Mail,
            //    "Booksaw abonelik onayı",
            //    "Merhaba booksawa abone olduğunuz için teşkkürler");


            return Ok("Abonelik başarılı");
        }

        private void SendMail(string toEmail)
        {
            var fromAddress = new MailAddress(smtpUser, "BookStore");
            var toAddress = new MailAddress(toEmail);

            var smtp = new SmtpClient
            {
                Host = smtpHost,
                Port = smtpPort,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(smtpUser, smtpPass)
            };

            using var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = "BookStore Aboneliğiniz Onaylandı",
                Body = "Merhaba, BookStore blogumuza abone olduğunuz için teşekkür ederiz! En son kitaplar ve haberler size ulaşacak.",
                IsBodyHtml = false
            };

            smtp.Send(message);
        }
    }
}






using BookStore.BusinessLayer.Abstract;
using BookStore.WebUI.Dtos.SubscribeDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Net;
using System.Runtime.CompilerServices;

namespace BookStore.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class SubscribeController : Controller
    {
        //private readonly ISubscribeService _subscribeService;
        private readonly IHttpClientFactory _httpClientFactory;

        public SubscribeController(/*ISubscribeService subscribeService,*/ IHttpClientFactory httpClientFactory)
        {
            //_subscribeService = subscribeService;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7293/api/Subscribe");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSubscribeDto>>(data);
                return View(values);
            }
            //var subscribe = _subscribeService.TGetAll();
            //return View(subscribe);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendsMail(string Subject, string Body)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7293/api/Subscribe");
            if (!response.IsSuccessStatusCode)
            {
                TempData["error"] = "Abone listesi alınamadı.";
                return RedirectToAction("Index");
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var emails = JsonConvert.DeserializeObject<List<ResultSubscribeDto>>(jsonData);

            foreach (var subscriber in emails)
            {
                using (var message = new MailMessage())
                {
                    message.From = new MailAddress("yusufkacmzz@gmail.com", "BookStore");
                    message.To.Add(subscriber.Mail);
                    message.Subject = Subject;
                    message.Body = Body;
                    message.IsBodyHtml = true;

                    using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("yusufkacmzz@gmail.com", "ubitjxmdyzxyyylz");
                        smtp.EnableSsl = true;
                        await smtp.SendMailAsync(message);
                    }
                }
            }

            TempData["success"] = "Tüm abonelere mail gönderildi.";
            return RedirectToAction("Index");
        }
    }
}

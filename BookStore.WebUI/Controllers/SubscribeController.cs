using BookStore.BusinessLayer.Abstract;
using BookStore.WebUI.Dtos.SubscribeDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace BookStore.WebUI.Controllers
{
    
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
    }
}

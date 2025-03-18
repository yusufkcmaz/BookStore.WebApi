
using BookStore.WebUI.Dtos.QuoteDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookStore.WebUI.ViewComponents
{
    public class _DefaultUIQuotationComponent :ViewComponent

    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultUIQuotationComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async  Task<IViewComponentResult> InvokeAsync()

        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7293/api/Quote/RandomQuote");
            if (response.IsSuccessStatusCode)

            {
                var data = await response.Content.ReadAsStringAsync();  
                var values = JsonConvert.DeserializeObject<RandomQuoteDto>(data);
                return View(values);
            }


            return View();  
        }
    }
}

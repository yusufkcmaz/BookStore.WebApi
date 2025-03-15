using BookStore.WebUI.Dtos.BillboardDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookStore.WebUI.ViewComponents
{
    public class _DefaultUIBillboardComponent :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultUIBillboardComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7293/api/Products");
            if (responsemessage.IsSuccessStatusCode)
            {
                var data = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBillboardDto>>(data);
                return View(values);
            }
            return View();
             
        }
    }
}

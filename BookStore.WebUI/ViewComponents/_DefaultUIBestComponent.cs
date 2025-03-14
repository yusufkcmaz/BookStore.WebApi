

using BookStore.WebUI.Dtos.ProductsDtos;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

namespace BookStore.WebUI.ViewComponents
{
    public class _DefaultUIBestComponent :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
       

        public _DefaultUIBestComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
          
        }



        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7293/api/Products/GetRandomProduct");
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetRandomProductDto>(data);
               

                return View(values);
            }

            // Eğer API'den veri alınamazsa, boş bir liste döndürüyoruz
            return View();
        }
    }
}


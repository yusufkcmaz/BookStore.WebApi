using BookStore.WebUI.Dtos.CategoryDtos;
using BookStore.WebUI.Dtos.ProductsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BookStore.WebUI.ViewComponents
{
    public class _DefaultUIPopularComponent :ViewComponent
    {
        private  readonly IHttpClientFactory _httpClientFactory;

        public _DefaultUIPopularComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7293/api/Products/GetCategoryAndWriter");
            if(responsemessage.IsSuccessStatusCode)
            {
                var data = await responsemessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(data);
          
                return View(value);
            }
           return View();
        }
    }
}

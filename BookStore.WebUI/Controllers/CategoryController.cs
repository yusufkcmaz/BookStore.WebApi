using BookStore.WebUI.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using static System.Net.WebRequestMethods;
//----<Swagger, API'yi test etmek için kullanabileceğimiz bir arayüzdür.---->//
namespace BookStore.WebUI.Controllers
{
    //Consuming işlemi, dış bir API'den veri almak anlamına gelir.(Tüketmek)
    public class CategoryController : Controller
    {
        //Bu controller, dış bir API ile etkileşime girmek için IHttpClientFactory kullanılır.


        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        // HTTP isteklerini yönetmek için komutlar kullanmak.
        public async Task<IActionResult> CategoryList()
        {
            //API çağrısı yapmak için HttpClient nesnesi oluşturuluyor.
            var client = _httpClientFactory.CreateClient();

            //Request URL --> API'den kategori listesini almak için GET isteği 
            var responseMessage = await client.GetAsync("https://localhost:7293/api/Categories");


            if (responseMessage.IsSuccessStatusCode)//--> Gelen yanıtın başarılı olup olmadığını kontrol ediyor.
            {
                // API'den dönen JSON formatındaki veriyi string olarak okuyoruz.
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                // JSON verisini ResultCategoryDto türünde bir listeye dönüştürme.
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

                return View(values);
            }
            return View();


        }

        [HttpGet]

        public IActionResult CreateCategory()
        {
            return View();
        }


        [HttpPost]

        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            //API İstek
            var client = _httpClientFactory.CreateClient();


            //API, Swagger üzerinden gelen JSON verisini alır.
            //JsonConvert.SerializeObject(createCategoryDto) ile C# nesnesi JSON formatına dönüştürülür ve API'ye gönderilir.
            //API, gelen JSON'u işleyip veritabanına kaydeder.
            var jsonData = JsonConvert.SerializeObject(createCategoryDto);

            //API'ye JSON formatında veri göndereceğimiz için, JSON verimizi StringContent nesnesine dönüştürüyoruz.
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            //Kategori verisini API'ye göndermek için POST isteği yapar
            //Verinin JSON formatında dönüştürülmesi
            var responseMessage = await client.PostAsync("https://localhost:7293/api/Categories", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoryList");
            }

            return View();
        }


        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:7293/api/Categories?id=" + id);
            return RedirectToAction("CategoryList");

        }
    }
}

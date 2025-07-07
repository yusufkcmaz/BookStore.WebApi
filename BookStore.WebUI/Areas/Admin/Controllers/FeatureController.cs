using BookStore.WebUI.Dtos.FeatureDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace BookStore.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class FeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //response:Cevap
        //client:almak
        public async Task<IActionResult> FeatureList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7293/api/Features");

            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(data);

                return View(values);
            }

            return View();
        }
        [HttpGet]
        public IActionResult AddFeature()
        {
            return View(new CreateFeatureDto());
        }

        [HttpPost]
        public async Task<IActionResult> AddFeature(CreateFeatureDto featureDto)
        {
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(featureDto);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7293/api/Features", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("FeatureList");
            }
            return View(featureDto);
        }

        public async Task<IActionResult> DeleteFeature(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:7293/api/Features=" + id);
            return RedirectToAction("FeatureList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeature(int id)

        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7293/api/Features/GetFeature?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetByIdFeatureDto>(data);
                return View(values);

            }
            return View();

        }

        [HttpPost]

        public async Task<IActionResult> UpdateFeature(UpdateFeatueDto featueDto)
        {
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(featueDto);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            var responsemessage = await client.PutAsync("https://localhost:7293/api/Features", content);
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("FeatureList");

            }
            return View();
        }
        public async Task<IActionResult> LastFourFeatures()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7293/api/Features/GetLastFourFeature");
            if (responsemessage.IsSuccessStatusCode)
            {
                var data = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(data);
                return View(values);
            }
            return View();
        }
    }
}

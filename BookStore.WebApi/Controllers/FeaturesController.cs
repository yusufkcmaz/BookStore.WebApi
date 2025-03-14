using BookStore.BusinessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //Feature API endpointleri.
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureService _featureService;

        public FeaturesController(IFeatureService featureService)
        {
            _featureService = featureService;
        }


        [HttpGet]
        public IActionResult FeatureList()
        {
            var result = _featureService.TGetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result =_featureService.TGetById(id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
                      

        }

        [HttpPost]
        public IActionResult Add(Feature feature)
        {
            _featureService.TAdd(feature);
            return Ok("Ekleme işlemi Başarılı");
        }

        [HttpPut]

        public IActionResult Update(Feature feature)
        {
            _featureService.TUpdate(feature);   
            return Ok("İşlem Başarılı");
        }

        [HttpDelete]

        public IActionResult Delete(int id)
        {
            var values = _featureService.TGetById(id);
            if (values == null)
            {
                return NotFound("Silmek istediğiniz özellik bulunamadı.");
            }

            _featureService.TDelete(id);
            return Ok("Başarılı"); 
        }

        [HttpGet("GetFeature")]
        public IActionResult GetFeatureCount()
        {
            return Ok(_featureService.TGetFeatureCount());
        }

        [HttpGet("GetLastFourFeature")]
        public IActionResult GetlastFourFeatures()
        {
            var result = _featureService.TGetAll()
                .OrderByDescending(x => x.FeatureId)
                .Take(4)
                .ToList();
            return Ok(result);
        }

    }

}


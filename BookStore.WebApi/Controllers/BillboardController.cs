using BookStore.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillboardController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IProductService _productService;

        public BillboardController(IHttpClientFactory httpClientFactory , IProductService productService)
        {
            _httpClientFactory = httpClientFactory;
            _productService = productService;
        }

        [HttpGet]
        public IActionResult BillboardList()
        {
            var values = _productService.TGetAll();
            return Ok(values);
        }
    }
}

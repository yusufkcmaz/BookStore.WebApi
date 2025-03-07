using BookStore.BusinessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]   

        public IActionResult ProductList()
        {
            return Ok(_productService.TGetAll());
        }

        [HttpPost]

        public IActionResult CreateProduct(Product _product)
        {
            _productService.TAdd(_product);
            return Ok("Ekleme işlemi başarılı ");
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product _product)
        {
            _productService.TUpdate(_product);
            return Ok("Güncelleme işlemi başarıyla tamamlandı");
        }

        [HttpDelete ]

        public IActionResult DeleteProduct(int id)
        {
            _productService.TDelete(id);
            return Ok("Silme işlemi başarılı");
        }

        [HttpGet("GetProduct")]

        public IActionResult GetProduct(int id)
        {
            return Ok(_productService.TGetById(id));
        }

        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            return Ok(_productService.TGetProductCount());
        }

    }
}

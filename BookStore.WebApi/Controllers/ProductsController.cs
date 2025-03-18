using AutoMapper;
using BookStore.BusinessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using BookStore.WebApi.Dtos.ApiProductDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using System.Runtime.CompilerServices;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;


        public ProductsController(IProductService productService, IMapper mapper, ICategoryService categoryService)
        {
            _productService = productService;
            _mapper = mapper;
            _categoryService = categoryService;

        }


        [HttpGet]

        public IActionResult ProductList()
        {

            //var product = _productService.TGetAll();

            //var dto = _mapper.Map<List<ResultProductDetailDto>>(product);
            //return Ok(dto);

            return Ok(_productService.TGetAll());
            ///
            //var product = _productService.TGetAll();
            //var productdto = _mapper.Map<List<ResultProductDetailDto>>(product);
            //return Ok(productdto);
        }



        [HttpGet("GetCategoryAndWriter")] 
        public IActionResult GetProductsWithCategories()
        {
            var product = _productService.TGetProductsWithCategories();
            var dto = _mapper.Map<List<ResultProductDetailDto>>(product);
            return Ok(dto);
        }


        [HttpPost]

        public IActionResult CreateProduct(CreateProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _productService.TAdd(product);
            return Ok("Ürün Ekleme Başarılı");
            //_productService.TAdd(_product);
            //return Ok("Ekleme işlemi başarılı ");
        }


        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto update)
        {
            var product = _mapper.Map<Product>(update);
            _productService.TUpdate(product);
            return Ok("Güncelleme başarılı kenks :");
            //_productService.TUpdate(_product);
            //return Ok("Güncelleme işlemi başarıyla tamamlandı");
        }

        [HttpDelete]

        public IActionResult DeleteProduct(int id)
        {
            _productService.TDelete(id);
            return Ok("Silme işlemi başarılı");
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var valuw = _productService.TGetById(id);
            return Ok(valuw);

            //return Ok (_productService.TGetById(id));
        }

        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            return Ok(_productService.TGetProductCount());
        }

        [HttpGet("GetRandomProduct")]
        public IActionResult GetRandomProduct()
        {
            var product = _productService.TGetRandomProduct();
            return Ok(product);
           

        }
        [HttpGet("GetLastFourFeature")]
        public IActionResult GetlastFourFeatures()
        {
            var result = _productService.TGetAll()
                .OrderByDescending(x => x.ProductId)
                .Take(4)
                .ToList();
            return Ok(result);
        }


    }
}

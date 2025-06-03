using AutoMapper;
using BookStore.BusinessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using BookStore.WebApi.Dtos.ApiCategoryDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static System.Net.WebRequestMethods;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
       // controller iş mantığı ilgilenir, yani ICategoryService kullanılır.
       private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        //  API endpoint olarak çalışır

        public IActionResult CategoryList()
        {
            var value = _categoryService.TGetAll();
            return Ok(value); //--> HTTP 200 OK döner
        }

        [HttpPost]
        //kategori verisini alır.JSON formatında gelir.
        public IActionResult CreateCategory(CreateCategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            _categoryService.TAdd(category);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.TDelete(id);
            return Ok("Silme işlemi başarılı");
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto update)
        {
            var category = _mapper.Map<Category>(update);
            _categoryService.TUpdate(category);
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpGet("GetCategoriesWithProducts")]
        public IActionResult GetCategoriesWithProducts()
        {
            var categories =  _categoryService.TGetCategoriesWithProducts(); // Kategorileri ve içindeki ürünleri çek

            if (categories == null || !categories.Any())
            {
                return NotFound("Kategoriler bulunamadı."); // Eğer veri yoksa 404 döndür
            }

            var categoryDtos = _mapper.Map<List<ResultCategoryDto>>(categories); // DTO'ya map et

            return Ok(categoryDtos); // JSON formatında döndür
        }


    }

}

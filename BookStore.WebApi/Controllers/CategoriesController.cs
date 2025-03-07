using BookStore.BusinessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
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
        public IActionResult CreateCategory(Category category)
        {
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
        public IActionResult UpdateCategory(Category category)
        {
            _categoryService.TUpdate(category);
            return Ok("Güncelleme işlemi başarılı");
        }
    }

}

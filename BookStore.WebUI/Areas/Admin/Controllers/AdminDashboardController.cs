using BookStore.DataAccessLayer.Abstract;
using BookStore.WebUI.ViewComponents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace BookStore.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    //[Authorize(Roles = "Admin")]
    public class AdminDashboardController : Controller
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IProductDal _productDal;
        private readonly ISubscribeDal _subscribeDal;
        private readonly IQuoteDal _quoteDal;
        private readonly IUserDal _userDal;

        public AdminDashboardController(ICategoryDal categoryDal, IProductDal productDal ,  ISubscribeDal subscribeDal , IQuoteDal quoteDal , IUserDal userDal)
        {
            _categoryDal = categoryDal;
            _productDal = productDal;
            _subscribeDal = subscribeDal;
            _quoteDal = quoteDal;
            _userDal = userDal;
        }

        public IActionResult Index()
        {

            ViewBag.CategoryCount = _categoryDal.GetAll().Count(); // kategori
            ViewBag.Products = _productDal.GetAll().Count(); // Ürün
            ViewBag.subcribe = _subscribeDal.GetAll().Count(); //Aboneler

            var totalPosts = _quoteDal.GetAll().Count();
            ViewBag.quote = totalPosts;

            var expensiveProduct = _productDal.GetAll()
                .OrderByDescending(p => p.ProductPrice)
                .FirstOrDefault();

            ViewBag.Product = expensiveProduct;




            ViewBag.user = _userDal.GetAll();
            var user = _userDal.GetAll();
            return View(user);

           
        }
    }
}

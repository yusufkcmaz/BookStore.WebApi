using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.Controllers
{
    public class AdminDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

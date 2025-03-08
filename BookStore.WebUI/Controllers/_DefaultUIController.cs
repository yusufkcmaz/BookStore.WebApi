using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.Controllers
{
    public class _DefaultUIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

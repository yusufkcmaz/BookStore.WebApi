using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.Controllers
{
    public class LoginController : Controller
    {
        public async Task<IActionResult> Index()
        {
                        return View();
        }
    }
}

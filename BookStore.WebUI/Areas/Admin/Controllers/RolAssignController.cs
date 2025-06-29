using BookStore.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolAssignController : Controller
    {
        private readonly UserManager<AppUser> _userManager ;

        public RolAssignController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public RolAssignController(RoleManager<IdentityRole<int>> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

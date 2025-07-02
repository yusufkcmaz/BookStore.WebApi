using BookStore.BusinessLayer.Concrete;
using BookStore.EntityLayer.Concrete;
using BookStore.WebUI.Dtos.UserDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            await _signInManager.SignOutAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return View(loginDto);
            }

            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Geçersiz email veya şifre");
                return View(loginDto);
            }

            if (!user.EmailConfirmed)
            {
                ModelState.AddModelError("", "Email adresiniz onaylanmamış.");
                return View(loginDto);
            }


            var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, isPersistent: false, lockoutOnFailure: false);
            // lockoutOnFailure ard arda başarıs girişlerde kitler : true durumda .

            if (result.Succeeded)
            {
                var roles = await _userManager.GetRolesAsync(user);

                if (roles.Contains("Admin"))
                    return RedirectToAction("Index", "AdminDashboard", new { area = "Admin" });

                if (roles.Contains("User"))
                    return RedirectToAction("Index", "MyProfile", new { area = "User" });

                return RedirectToAction("Index", "_DefaultUI", new { area = "" });
            }

            ModelState.AddModelError("", "Geçersiz Email veya Şifre");
            return View(loginDto);

        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
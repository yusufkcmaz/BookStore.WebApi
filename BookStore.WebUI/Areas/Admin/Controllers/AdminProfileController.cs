using BookStore.EntityLayer.Concrete;
using BookStore.WebUI.Dtos.AdminProfileDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace BookStore.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var model = new AdminProfileDto
            {
                Name = user.FirstName,
                Surname = user.LastName,
                Email = user.Email,
                ImageUrl = user.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AdminProfileDto model)
        {
            if (!ModelState.IsValid) return View(model);  //Boş bırakılma

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            user.FirstName = model.Name;
            user.LastName = model.Surname;
            user.Email = model.Email;
            user.ImageUrl = model.ImageUrl;

           
            if (!string.IsNullOrEmpty(model.NewPassword))  //Boş mu dolumu 
            {
                if (model.NewPassword != model.ConfirmNewPassword)
                {
                    ModelState.AddModelError("", "Yeni şifreler uyuşmuyor.");
                    return View(model);
                }

                var passwordCheck = await _userManager.CheckPasswordAsync(user, model.CurrentPassword);
                if (!passwordCheck) //Mevcut şifre doğruluk kontrolü "CheckPassword"
                {
                    ModelState.AddModelError("", "Mevcut şifre hatalı.");
                    return View(model);
                }

                var passwordChangeResult = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (!passwordChangeResult.Succeeded)
                {
                    foreach (var error in passwordChangeResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);

                    //Mevcut şifreyi doğrulama yeni şifre oluşturma
                }
            }

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                TempData["Message"] = "Profil güncellendi!";
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }
    }
}

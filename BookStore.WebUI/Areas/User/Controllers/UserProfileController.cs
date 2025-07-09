using BookStore.BusinessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using BookStore.WebUI.Dtos.UserDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class UserProfileController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;

        public UserProfileController(IUserService userService, UserManager<AppUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Index", "DefaultUI");/*, new { area = "" });*/
            }

            var userProfile = new UpdateProfilDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                ImageUrl = user.ImageUrl
            };

            return View(userProfile);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Index", "DefaultUI");
            }

            var model = new UpdateProfilDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                ImageUrl = user.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile(UpdateProfilDto updateProfilDto)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Index", "DefaultUI");
            }

            if (ModelState.IsValid)
            {
                user.FirstName = updateProfilDto.FirstName;
                user.LastName = updateProfilDto.LastName;
                user.UserName = updateProfilDto.UserName;
                user.Email = updateProfilDto.Email;
                user.ImageUrl = updateProfilDto.ImageUrl;

                // Şifre değişikliği istenmiş mi?
                if (!string.IsNullOrEmpty(updateProfilDto.CurrentPassword) &&
                    !string.IsNullOrEmpty(updateProfilDto.NewPassword))
                {
                    var passwordResult = await _userManager.ChangePasswordAsync(
                        user,
                        updateProfilDto.CurrentPassword,
                        updateProfilDto.NewPassword
                    );

                    if (!passwordResult.Succeeded)
                    {
                        foreach (var error in passwordResult.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                        return View(updateProfilDto);
                    }
                }

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    TempData["SuccessMessage"] = "Profil güncellendi.";
                    return RedirectToAction("UpdateProfile");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(updateProfilDto);
        }
    }
}
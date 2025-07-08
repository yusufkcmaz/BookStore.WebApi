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

            var userProfile = new ResultUserDto
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
                return RedirectToAction("Index", "DefaultUI");/*, new { area = "" });*/
            }

            var model = new ResultUserDto
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
        public async Task<IActionResult> UpdateProfile(ResultUserDto resultUserDto)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Index", "DefaultUI");/*, new { area = "" });*/
            }

            if (ModelState.IsValid)
            {
                user.FirstName = resultUserDto.FirstName;
                user.LastName = resultUserDto.LastName;
                user.UserName = resultUserDto.UserName;
                user.Email = resultUserDto.Email;
                user.ImageUrl = resultUserDto.ImageUrl;

                if (!string.IsNullOrEmpty(resultUserDto.CurrentPassword) &&
                    !string.IsNullOrEmpty(resultUserDto.NewPassword))
                {
                    var passwordResult = await _userManager.ChangePasswordAsync(
                        user,
                        resultUserDto.CurrentPassword,
                        resultUserDto.NewPassword);

                    if (!passwordResult.Succeeded)
                    {
                        ModelState.AddModelError(string.Empty, "Şifre güncellenirken bir hata oluştu.");
                        return View(resultUserDto);
                    }
                }

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    TempData["SuccessMessage"] = "Profil Güncellendi";
                    return RedirectToAction("Index", "DefaultUI");/*, new { area = "" });*/
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Profil güncellenirken bir hata oluştu.");
                }
            }

            return View(resultUserDto);
        }
    }
}

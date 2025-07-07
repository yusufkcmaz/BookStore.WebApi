using BookStore.EntityLayer.Concrete;
using BookStore.WebUI.Dtos.AdminProfileDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.ViewComponents
{

    public class _AdminNavbarComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _AdminNavbarComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }



        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            var model = new AdminNavbarProfileDto
            {
                Name = user?.FirstName ?? "Guest",
                Email = user?.Email ?? "",
                ProfilePictureUrl = user?.ImageUrl ?? "/kaiadmin-lite-1.2.0/assets/img/profile.jpg"
            };

            return View(model);
        }
    }

   
}


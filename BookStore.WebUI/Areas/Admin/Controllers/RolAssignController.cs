using BookStore.EntityLayer.Concrete;
using BookStore.WebUI.Dtos.RoleDtos;
using BookStore.WebUI.Dtos.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RolAssignController : Controller
    {


        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public RolAssignController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();

            var userdto = new List<ResultUserDto>();
            foreach (var user in users)
            {
                var dto = new ResultUserDto();

                dto.Roles = await _userManager.GetRolesAsync(user);
                dto.Id = user.Id;
                dto.FirstName = user.FirstName;
                dto.UserName = user.UserName;
                dto.LastName = user.LastName;
                dto.Email = user.Email;

                userdto.Add(dto);
            }

            return View(userdto);

        }

        [HttpGet]
        public async Task<ActionResult> AssignRole(int id)
        {


            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                TempData["Error"] = "Kullanıcı bulunamadı.";
                return RedirectToAction("Index"); // veya NotFound() ya da özel hata sayfası
            }

            ViewBag.fullName = $"{user.FirstName} {user.LastName}";

            var roles = await _roleManager.Roles.ToListAsync();

            var userRoles = await _userManager.GetRolesAsync(user);

            var assignRoleDtoList = new List<RoleAssign>();

            foreach (var item in roles)
            {
                var model = new RoleAssign();
                model.UserId = user.Id;
                model.RoleName = item.Name;
                model.RoleId = item.Id;
                model.RoleExist = userRoles.Contains(item.Name);

                assignRoleDtoList.Add(model);
            }
            return View(assignRoleDtoList);



        }



        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssign> model)
        {
            var userId = model.Select(x => x.UserId).FirstOrDefault();

            var user = await _userManager.FindByIdAsync(userId.ToString());

            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var item in model)
            {
                // Admin rolünü kaldırmayı engelleme
                if (item.RoleName == "Admin" && user.UserName == "superadmin")
                {
                    // "SuperAdmin" rolünü silmeye çalışıyorsan işlem yapma
                    continue;
                }

                // Ekleme işlemi (rol varsa ve atanmadıysa)
                if (item.RoleExist && !userRoles.Contains(item.RoleName))
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                // Silme işlemi (rol artık kaldırıldıysa)
                else if (!item.RoleExist && userRoles.Contains(item.RoleName))
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }
            await _userManager.UpdateAsync(user);

            TempData["SuccessMessage"] = "Rol atamaları güncellendi.";
            return RedirectToAction("Index");



        }


    }
}

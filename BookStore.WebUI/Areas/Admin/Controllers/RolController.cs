using BookStore.EntityLayer.Concrete;
using BookStore.WebUI.Dtos.RoleDtos;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;


namespace BookStore.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolController : Controller
    {

        private readonly RoleManager<AppRole> _rolesManager;

        public RolController(RoleManager<AppRole> rolesManager)
        {
            _rolesManager = rolesManager;
        }
            

        public IActionResult Index()
        {
            var roles = _rolesManager.Roles.ToList();

            var dto = roles.Adapt<List<ResultRoleDto>>();
            return View(dto);
        }


        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleDto model)
        {
            var role = model.Adapt<AppRole>();
            var result = await _rolesManager.CreateAsync(role);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    return View(model);
                }

            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await _rolesManager.FindByIdAsync(id.ToString());
            await _rolesManager.DeleteAsync(role);
            return RedirectToAction("Index");

        }

        //public async Task<IActionResult> UpdateRole(int id)
        //{
        //    var role = await _rolesManager.FindByIdAsync(id.ToString());
        //    var updateDto = role.Adapt<UpdateaRoleDto>();
        //    return View(updateDto);
        //}

        //[HttpPost]
        //public async Task<IActionResult> UpdateRole(UpdateaRoleDto model)
        //{
        //    var role = model.Adapt<AppRole>();
        //    var result = await _rolesManager.UpdateAsync(role);
        //    if (!result.Succeeded)
        //    {
        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError(string.Empty, error.Description);
        //            return View(model);
        //        }

        //    }
        //    return RedirectToAction("Index");
        //}
    }
}

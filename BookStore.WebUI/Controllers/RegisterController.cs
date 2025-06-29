using BookStore.BusinessLayer.Abstract;
using BookStore.BusinessLayer.Concrete;
using BookStore.EntityLayer.Concrete;
using BookStore.WebUI.Dtos.RegisterDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.CompilerServices;

namespace BookStore.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailSender _emailSender;
        public RegisterController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager,IEmailSender emailSender)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _emailSender = emailSender;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return View(registerDto);
            }

            var user = new AppUser
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                UserName = registerDto.UserName,

            };

            var result = await _userManager.CreateAsync(user , registerDto.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                //Email onay token
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action(nameof(ConfirmEmail), "Register",
                    new { userID = user.Id, token = token }, Request.Scheme);
                //Console.WriteLine($"Email doğrulama Linki : {confirmationLink}");
                string mailBody = $"Email doğrulama linkiniz: <a href='{confirmationLink}'>Buraya tıklayın</a>";
                await _emailSender.SendEmailAsync(user.Email, "Email Onay", mailBody);
                return View("RegisterConfirmation");

            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(registerDto);
        }

        public async Task<IActionResult> ConfirmEmail(int userId, string token)
        {
            if (userId == 0 || token == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return View("ConfirmEmail"); // Onay başarılıysa gösterilecek view
            }
            else
            {
                return View("Error"); // Onay başarısızsa gösterilecek view
            }
        }
    }
}


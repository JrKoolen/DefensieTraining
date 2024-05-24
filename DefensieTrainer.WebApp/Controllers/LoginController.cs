using DefensieTrainer.Domain.DTO;
using DefensieTrainer.Domain.IServices;
using DefensieTrainer.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DefensieTrainer.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("~/Views/Login/Login.cshtml");
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserDto user = _userService.AuthenticateUser(model.Email, model.Password);
                if (user != null)
                {
                    ViewBag.UserEmail = user.Email;
                    ViewBag.UserName = user.Name;
                    return View("~/Views/Home/Index.cshtml"); // Assuming your home page is named Index.cshtml
                }
                ModelState.AddModelError("", "Invalid login attempt.");
            }
            return View(model);
        }

    }
}

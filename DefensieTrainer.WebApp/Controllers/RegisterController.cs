using DefensieTrainer.Domain.DTO;
using DefensieTrainer.Domain.IServices;
using DefensieTrainer.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DefensieTrainer.WebApp.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IPersonService _userService;
        public RegisterController(IPersonService userService)
        {
            _userService = userService;
        }

        [Authorize]
        public IActionResult Register()
        {
            return View("~/Views/Account/Register.cshtml");
        }

        [Authorize]
        public IActionResult CreateUser(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                _userService.CreateUser(model.ToPostDto());
                return RedirectToAction("Login", "Login");
            }
            else
            {
                return View("~/Views/Account/Register.cshtml", model);
            }
        }
    }
}

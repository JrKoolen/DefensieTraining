using Microsoft.AspNetCore.Mvc;
using DefensieTrainer.Domain.IServices;
using DefensieTrainer.Domain.DTO;
using DefensieTrainer.WebApp.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DefensieTrainer.WebApp.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IUserServices _userServices;

        public RegisterController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        public IActionResult Register()
        {
            return View("~/Views/Account/Register.cshtml");
        }

        public IActionResult CreateUser(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                _userServices.CreateUser(model.ToPostDto());
                return RedirectToAction("Login");
            }
            else
            {
                return View(model);
            }
        }
    }
}

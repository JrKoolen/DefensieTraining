using Microsoft.AspNetCore.Mvc;
using DefensieTrainer.WebApp.Models;

namespace DefensieTrainer.WebApp.Controllers
{
    public class RegisterController : Controller
    {

        public IActionResult Register()
        {
            return View("~/Views/Account/Register.cshtml");
        }

        public IActionResult CreateUser(UserViewModel model)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("Login");
            }
            return View(model);
        }
    }
}

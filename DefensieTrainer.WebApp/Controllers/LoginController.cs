using DefensieTrainer.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DefensieTrainer.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(UserViewModel model)
        {
            return RedirectToAction("Index", "Dashboard");
        }
    }
}

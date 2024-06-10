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
        private readonly IClusterService _clusterService;
        public RegisterController(IPersonService userService, IClusterService clusterService)
        {
            _userService = userService;
            _clusterService = clusterService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            List<ClusterDto> allClusters = _clusterService.GetAllClusters();
            var Model = new RegisterViewModel();
            foreach (ClusterDto cluster in allClusters)
            {
                Model.AppendCLusterLevel(cluster.ClusterLevel);
            }
            return View("~/Views/Account/Register.cshtml", Model);
        }

        [HttpPost]
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

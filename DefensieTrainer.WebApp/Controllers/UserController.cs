using DefensieTrainer.Domain.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DefensieTrainer.WebApp.Models;
using DefensieTrainer.Domain.DTO;

namespace DefensieTrainer.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly ITrainingService _trainingService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(ITrainingService trainingService, IHttpContextAccessor httpContextAccessor)
        {
            _trainingService = trainingService;
            _httpContextAccessor = httpContextAccessor;
        }



        [HttpGet]
        //[Authorize(Roles = "User")]
        public IActionResult Dashboard()
        {
            return View("~/Views/User/Dashboard.cshtml");
        }

        [HttpGet]
        //[Authorize(Roles = "User")]
        public IActionResult NewTraining()
        {
            return View("~/Views/User/NewTraining.cshtml");
        }

        [HttpGet]
        //[Authorize(Roles = "User")]
        public IActionResult LatestTraining()
        {
            return View("~/Views/User/LatestTraining.cshtml");
        }

        //[Authorize(Roles = "User")]
        public IActionResult NewTraining(UserTrainingViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserTrainingInputDto input = model.ToDto();
                input.ClusterId = _httpContextAccessor.HttpContext.Session.GetInt32("ClusterId");
                input.ClusterId = _httpContextAccessor.HttpContext.Session.GetInt32("ClusterId");
                return RedirectToAction("Dashboard");
            }
            return View("~/Views/User/NewTraining.cshtml", model);
        }
    }

}


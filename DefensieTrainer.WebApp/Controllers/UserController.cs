using DefensieTrainer.Domain.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DefensieTrainer.WebApp.Controllers
{
    public class UserController : Controller
    {

        private readonly ITrainingService _trainingService;

        public UserController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }



        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Dashboard()
        {
            return View("~/Views/User/Dashboard.cshtml");
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult NewTraining()
        {
            return View("~/Views/User/NewTraining.cshtml");
        }
    }
}

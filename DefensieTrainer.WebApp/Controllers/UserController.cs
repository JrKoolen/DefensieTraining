using DefensieTrainer.Domain.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DefensieTrainer.WebApp.Models;
using DefensieTrainer.Domain.DTO;
using System.Security.Claims;

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
        [Authorize(Roles = "User")]
        public IActionResult Dashboard()
        {
            if (User.Identity.IsAuthenticated)
            {
                string email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                DashboardDto dto =  _trainingService.GetDashboardByEmail(email);
                var model = new DashboardViewModel
                {
                    UserClusterId = dto.ClusterLevel,
                    AmountOfCompletedTrainings = dto.AmountOfCompletedTrainings,
                    LatestFinishedTraining = dto.LatestFinishedTraining,
                    UserDeadline = dto.UserDeadline,
                };
                return View(model);
            }
            else 
            { 
                return View(); 
            }  
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult NewTraining(NextTrainingForUserViewModel model)
        {
            return View("~/Views/User/NewTraining.cshtml");
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult LatestTraining()
        {
            string email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            TrainingDto Dto = _trainingService.CreateNewTraining(email);
            var model = new NextTrainingForUserViewModel
            {
                Name = Dto.Name,
                Description = Dto.Description,
                Amount = Dto.Amount,
                Meters = Dto.Meters,
                SortTraining = Dto.SortTraining,
                TimeInSeconds = Dto.TimeInSeconds,

            };
            return View(model);
        }

        [Authorize(Roles = "User")]
        public IActionResult NewTraining(UserTrainingViewModel model)
        {
            return View("~/Views/User/NewTraining.cshtml", model);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult SubmitTraining(UserTrainingViewModel model)
        { 
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    string email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

                    _trainingService.AddNewTraining(email, model.ToDto());
                    return RedirectToAction("Dashboard");
                }
            }
            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult Feedback()
        {
            string email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            FeedbackDto dto = _trainingService.GetFeedbackByEmail(email);
            var model = new FeedbackViewModel
            {
                Feedback = dto.Feedback
            };
            return View("~/Views/User/Feedback.cshtml", model);
        }
    }

}


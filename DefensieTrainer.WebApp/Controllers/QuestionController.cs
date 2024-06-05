using DefensieTrainer.Dal.Repositories;
using DefensieTrainer.Domain.DTO;
using DefensieTrainer.Domain.IServices;
using DefensieTrainer.WebApp.Constants;
using DefensieTrainer.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DefensieTrainer.WebApp.Controllers
{
    [Authorize(Roles = "Coach")]
    public class QuestionController : Controller
    {
        private readonly ITrainingService _trainingService;

        public QuestionController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        [HttpGet]
        public IActionResult ReceiveNextQuestion()
        {
            var training = _trainingService.GetOldestTraining();
            if (training == null)
            {
                return NotFound();
            }

            var sortTrainingDictionary = TrainingTypes.SortTraining
                .ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value);

            var model = new TrainingFeedbackViewModel
            {
                TrainingId = training.Id,
                Name = training.Name,
                Description = training.Description,
                Amount = training.Amount,
                Meters = training.Meters,
                SortTraining = sortTrainingDictionary, 
                TimeInSeconds = training.TimeInSeconds
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Feedback(TrainingFeedbackViewModel model)
        {
            if (ModelState.IsValid)
            {
               // _trainingService.SaveFeedback(model.TrainingId, User.Identity.Name, model.Feedback); 
                return RedirectToAction("FeedbackSubmitted");
            }

            return View(model);
        }

        public IActionResult FeedbackSubmitted()
        {
            return View();
        }
    }
}

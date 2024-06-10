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
                return RedirectToAction("NoQuestionsAvailable");
            }

            int trainingSortKey = training.SortTraining;
            string sortTrainingValue;
            if (!TrainingTypes.SortTraining.TryGetValue(trainingSortKey, out sortTrainingValue))
            {
                sortTrainingValue = "Default Value or Handle Null";
            }
            var model = new TrainingFeedbackViewModel
            {
                TrainingId = training.Id,
                Name = training.Name,
                Description = training.Description,
                Amount = training.Amount,
                Meters = training.Meters,
                SortTraining = sortTrainingValue,
                TimeInSeconds = training.TimeInSeconds,
                PersonId = training.PersonId,
            };
            return View(model);
        }


        [HttpGet]
        public IActionResult NoQuestionsAvailable()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Feedback(TrainingFeedbackViewModel model)
        {
            if (model.Feedback is not null)
            {
                CreateFeedbackDto dto = new()
                {
                    TrainingId = model.TrainingId,
                    PersonId = model.PersonId,
                    Feedback = model.Feedback,
                };
                _trainingService.SaveFeedBack(dto);
            }
            return RedirectToAction("ReceiveNextQuestion");
        }
    }
}

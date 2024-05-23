using DefensieTrainer.Domain.IServices;
using DefensieTrainer.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DefensieTrainer.WebApp.Controllers
{
    public class TrainingController : Controller
    {
        private readonly ITrainingService _trainingService;

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

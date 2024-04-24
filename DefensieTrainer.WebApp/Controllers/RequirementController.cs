using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DefensieTrainer.Domain.IServices;
using DefensieTrainer.Domain.DTO.IN;

namespace DefensieTraining.Controllers
{
    public class RequirementController : Controller
    {
        readonly TrainingManager TrainingManager = new();
        private readonly IRequirementServices _requirementService;

        public RequirementController(IRequirementServices requirementService)
        {
            _requirementService = requirementService;
        }

        public IActionResult ClusterManager()
        {
            return View();
        }

        public IActionResult CreateRequirement(RequirementViewModel model)
        {
            model.SortTrainingOptions = TrainingManager.GetTrainingOptions();


            if (ModelState.IsValid)
            {
               _requirementService.CreateRequirement(model.ToDto());
                return RedirectToAction("Index", "Home"); 
            }
            return View(model);
        }
        public IActionResult ViewCluster()
        {
            return View();
        }

    }
}

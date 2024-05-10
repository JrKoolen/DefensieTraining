using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DefensieTrainer.Domain.IServices;
using DefensieTrainer.Domain.DTO.IN;
using DefensieTrainer.WebApp.Models;

namespace DefensieTraining.Controllers
{
    public class ClusterController : Controller
    {
        private readonly IClusterService _clusterService;
        private readonly TrainingManager TrainingManager = new();
        private readonly IRequirementServices _requirementService;


        public ClusterController(IClusterService clusterService, IRequirementServices requirementService)
        {
            _clusterService = clusterService;
            _requirementService = requirementService;
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

        public IActionResult CreateCluster(ClusterViewModel model)
        {
            if (ModelState.IsValid)
            {
                _clusterService.CreateCluster(model.ToDto());
                ViewBag.CreatedCluster = true;
            }
            return RedirectToAction("ClusterManager");
        }


        public IActionResult ClusterManager()
        {
            var viewModel = new ClusterViewModel();
            viewModel.Requirements = _requirementService.GetAllRequirements();
            return View(viewModel);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DefensieTrainer.Domain.IServices;
using DefensieTrainer.WebApp.Models;
using DefensieTrainer.Domain.DTO;
using Microsoft.AspNetCore.Authorization;

namespace DefensieTraining.Controllers
{
    [Authorize(Roles = "Manager")]
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

        [Authorize(Roles = "Manager")]
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
        [Authorize(Roles = "Manager")]
        public IActionResult CreateCluster(ClusterViewModel model, string viewRequirements)
        {
            if (!string.IsNullOrEmpty(viewRequirements))
            {
                int selectedRequirementId = int.Parse(viewRequirements);
            }

            if (ModelState.IsValid) 
            {
                _clusterService.CreateCluster(model.ToDto());
                ViewBag.CreatedCluster = true;
                return RedirectToAction("ClusterManager");
            }
            else 
            { 
                return View(model); 
            }
            
        }

        [Authorize(Roles = "Manager")]
        public IActionResult  ClusterManager()
        {
            
            var viewModel = new ClusterViewModel();
            viewModel.Requirements = _requirementService.GetAllRequirements();
            viewModel.Clusters = _clusterService.GetAllClusters();
            return View(viewModel);
        }
        [Authorize(Roles = "Manager")]
        public IActionResult SaveClusters(ClusterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the list of clusters from the ModelState
                var clustersEntry = ModelState["Clusters"];

                // Check if the entry for "Clusters" exists and is of the correct type
                if (clustersEntry != null && clustersEntry.RawValue is List<CreateClusterDto> clusters)
                {
                    // Loop through each cluster and call the ChangeCluster method
                    foreach (var cluster in clusters)
                    {
                        _clusterService.ChangeCluster(cluster);
                    }
                }
            }
            else { return View(); }

            return RedirectToAction("ClusterManager");
        }

    }
}

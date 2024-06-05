using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DefensieTrainer.Domain.IServices;
using DefensieTrainer.WebApp.Models;
using DefensieTrainer.Domain.DTO;
using DefensieTrainer.WebApp.Constants;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics.Metrics;


namespace DefensieTraining.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ClusterController : Controller
    {
        private readonly IClusterService _clusterService;
        private readonly IRequirementServices _requirementService;
        private readonly IPersonService _personService;

        public ClusterController(IClusterService clusterService, IRequirementServices requirementService, IPersonService personService)
        {
            _clusterService = clusterService;
            _requirementService = requirementService;
            _personService = personService;
        }

        [Authorize(Roles = "Manager")]
        public IActionResult CreateRequirement(RequirementViewModel model)
        {
            model.SortTrainingOptions = TrainingTypes.SortTraining.Select(tt => new SelectListItem
            {
                Value = tt.Key.ToString(),
                Text = tt.Value
            }).ToList();

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
        public IActionResult ClusterManager()
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
                var clustersEntry = ModelState["Clusters"];

                if (clustersEntry != null && clustersEntry.RawValue is List<CreateClusterDto> clusters)
                {
                    foreach (var cluster in clusters)
                    {
                        _clusterService.ChangeCluster(cluster);
                    }
                }
            }
            else
            {
                return View();
            }
            return RedirectToAction("ClusterManager");
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        public IActionResult RoleAssignment()
        {
            var model = new RoleAssignmentViewModel
            {
                Roles = RoleTypes.roles.ToDictionary(role => role.Key.ToString(), role => role.Value)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(RoleAssignmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                _personService.UpdateUserRole(model.Email, model.GetRoleName());
            }
            return View("Succes");
        }
    }
}

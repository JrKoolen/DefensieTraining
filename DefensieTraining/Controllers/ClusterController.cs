using Dal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DefensieTraining.Controllers
{
    public class ClusterController : Controller
    {
        TrainingManager trainingManager = new();

        public IActionResult ClusterManager()
        {
            return View();
        }

        public IActionResult CreateRequirement(RequirementViewModel model)
        {
            model.SortTrainingOptions = trainingManager.GetTrainingOptions();



            if (ModelState.IsValid)
            {

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

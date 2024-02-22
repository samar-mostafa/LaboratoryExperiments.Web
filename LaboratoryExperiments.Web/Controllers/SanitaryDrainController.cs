using LaboratoryExperiments.Web.Data;
using LaboratoryExperiments.Web.Data.DomainModels;
using LaboratoryExperiments.Web.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LaboratoryExperiments.Web.Controllers
{
    public class SanitaryDrainController : Controller
    {
        private readonly ApplicationDbContext db;

        public SanitaryDrainController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var SanitaryDrain = db.SanitaryDrain.Select(b => new BranchViewModel
            {
                Id = b.Id,
                Name = b.Name,
                Stations = b.Stations.Select(s => s.Name).ToList()
            });
            return View(SanitaryDrain);
        }


        public IActionResult Create()
        {
            return PartialView("_Form");
        }
        [HttpPost]
        public IActionResult Create(CreateBranchViewModel mdl)
        {
            if (!ModelState.IsValid)
                return PartialView("_Form", mdl);

            var entity = new SanitaryDrain
            {
                Name = mdl.Name
            };
            db.SanitaryDrain.Add(entity);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AllowItem(CreateBranchViewModel model)
        {
            var branch = db.SanitaryDrain.SingleOrDefault(c => c.Name == model.Name);
            var isAllowed = branch is null || branch.Id.Equals(model.Id);
            return Json(isAllowed);
        }

        public IActionResult Delete(int id)
        {
            var branch = db.SanitaryDrain.Find(id);
            db.SanitaryDrain.Remove(branch);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

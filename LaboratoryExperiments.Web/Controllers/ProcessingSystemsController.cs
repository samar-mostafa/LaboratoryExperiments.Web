using LaboratoryExperiments.Web.Data;
using LaboratoryExperiments.Web.Data.DomainModels;
using LaboratoryExperiments.Web.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LaboratoryExperiments.Web.Controllers
{
    [Authorize]
    public class ProcessingSystemsController : Controller
    {
        private readonly ApplicationDbContext db;
        public ProcessingSystemsController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var ProcessingSystems = db.ProcessingSystems.Select(b => new ProcessingSystemViewModel
            {   Id=b.Id,
                Name = b.Name,                
            });
            return View(ProcessingSystems);
        }

        
        public IActionResult Create()
        {
            return PartialView("_Form");
        }
        [HttpPost]
        public IActionResult Create(CreateBranchViewModel mdl)
        {
            if(!ModelState.IsValid) 
                return PartialView("_Form",mdl);

            var entity = new ProcessingSystem
            {
                Name = mdl.Name
            };
            db.ProcessingSystems.Add(entity);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        
            public IActionResult AllowItem(CreateBranchViewModel model)
        {
            var branch = db.ProcessingSystems.SingleOrDefault(c => c.Name == model.Name);
            var isAllowed = branch is null || branch.Id.Equals(model.Id);
            return Json(isAllowed);
        }

        public IActionResult Delete(int id)
        {
            var branch = db.ProcessingSystems.Find(id);
            db.ProcessingSystems.Remove(branch);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

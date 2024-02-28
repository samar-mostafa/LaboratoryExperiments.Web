using LaboratoryExperiments.Web.Data;
using LaboratoryExperiments.Web.Data.DomainModels;
using LaboratoryExperiments.Web.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryExperiments.Web.Controllers
{
    [Authorize]
    public class UnitController : Controller
    {
        private readonly ApplicationDbContext db;

        public UnitController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var Units = db.Units.Select(b => new BranchViewModel
            {
                Id = b.Id,
                Name = b.Name,
            });
            return View(Units);
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

            var entity = new Unit
            {
                Name = mdl.Name
            };
            db.Units.Add(entity);
            db.SaveChanges();
            return Ok();
        }

        public IActionResult AllowItem(CreateBranchViewModel model)
        {
            var unit = db.Units.SingleOrDefault(c => c.Name == model.Name);
            var isAllowed = unit is null || unit.Id.Equals(model.Id);
            return Json(isAllowed);
        }

        public IActionResult Delete(int id)
        {
            var unit = db.Units.Find(id);
            db.Units.Remove(unit);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

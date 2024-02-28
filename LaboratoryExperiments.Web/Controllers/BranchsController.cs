using LaboratoryExperiments.Web.Data;
using LaboratoryExperiments.Web.Data.DomainModels;
using LaboratoryExperiments.Web.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace LaboratoryExperiments.Web.Controllers
{
    [Authorize]
    public class BranchsController : Controller
    {
        private readonly ApplicationDbContext db;

        public BranchsController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var branches = db.Branches.Include(b => b.Stations).Select(b => new BranchViewModel
            { Id=b.Id,
                Name = b.Name,
                Stations = b.Stations.Select(s =>new IdNameViewModel
                {
                    Id=s.Id,
                    Name = s.Name,
                }).ToList()
            });
            return View(branches);
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

            var entity = new Branch
            {
                Name = mdl.Name
            };
            db.Branches.Add(entity);
            db.SaveChanges();
            return Ok();
        }
        
            public IActionResult AllowItem(CreateBranchViewModel model)
        {
            var branch = db.Branches.SingleOrDefault(c => c.Name == model.Name);
            var isAllowed = branch is null || branch.Id.Equals(model.Id);
            return Json(isAllowed);
        }

        public IActionResult Delete(int id)
        {
            var branch = db.Branches.Find(id);
            db.Branches.Remove(branch);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

using AutoMapper;
using LaboratoryExperiments.Web.Data;
using LaboratoryExperiments.Web.Data.DomainModels;
using LaboratoryExperiments.Web.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryExperiments.Web.Controllers
{
    [Authorize]
    public class ExperimentsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public ExperimentsController(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var entities = db.Experiments.Include(e=>e.Unit).Include(e => e.ExperimentType).ToList();
            var data = mapper.Map<IEnumerable<ExperimentViewModel>>(entities); 
            return View(data);
        }

        public IActionResult Create()
        {
            ViewBag.Units = db.Units.OrderBy(u =>u.Name).Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name }).ToList(); ;
            ViewBag.ExperimentTypes = db.ExperimentTypes.OrderBy(u => u.Name).Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name }).ToList(); ;
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateExperimentViewModel mdl)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var entity = mapper.Map<Experiment>(mdl);
            db.Experiments.Add(entity);
            db.SaveChanges();
            return Ok("Experiment saved successfully");
        }

        public IActionResult AllowItem(CreateExperimentViewModel model)
        {
            var station = db.Stations.SingleOrDefault(c => c.Name == model.Name);
            var isAllowed = station is null || station.Id.Equals(model.Id);
            return Json(isAllowed);
        }

        public IActionResult Delete(int id)
        {
            var expriment = db.Experiments.Find(id);
            db.Experiments.Remove(expriment);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

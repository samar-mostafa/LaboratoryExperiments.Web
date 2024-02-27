using AutoMapper;
using LaboratoryExperiments.Web.Data;
using LaboratoryExperiments.Web.Data.DomainModels;
using LaboratoryExperiments.Web.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace LaboratoryExperiments.Web.Controllers
{
    public class TestsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;
        public TestsController(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var entities = db.Tests.Include(t=>t.Experiment).ThenInclude(e=>e.ExperimentType)
                .Include(t => t.Station).ThenInclude(s => s.Branch)
                 .Include(t => t.Station).ThenInclude(s => s.SanitaryDrain).ToList().OrderByDescending(t=>t.Id);
            var data = mapper.Map<IEnumerable<TestViewModel>>(entities);
            return View(data);
        }

        public IActionResult Create()
        {
            ViewBag.Stations = db.Stations.OrderBy(b => b.Name).Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name }).ToList();
            ViewBag.Experiments = db.Experiments.OrderBy(b => b.Name).Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name }).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateTestViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var experiment = db.Experiments.Find(model.ExperimentId);
            if ((model.In_Eff == false || model.In_Eff == true) && 
                (experiment.InffleuntValue == null || experiment.EffleuntValue == null))
                model.Result = true;
           else if (model.In_Eff == false)            
                model.Result = experiment.InffleuntValue >= model.EnteredValue; 
            else
                model.Result = experiment.EffleuntValue >= model.EnteredValue;

            var entity = mapper.Map<Test>(model);
            db.Tests.Add(entity);
            db.SaveChanges();

            var res = model.Result ? "Identical" : "Not matching";
            return Ok(res);
        }
    }
}

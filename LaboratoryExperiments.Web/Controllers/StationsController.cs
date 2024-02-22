using AutoMapper;
using LaboratoryExperiments.Web.Data;
using LaboratoryExperiments.Web.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryExperiments.Web.Controllers
{
    public class StationsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;
        public StationsController(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var stations = db.Stations.Include(s=>s.SanitaryDrain).
                Include(s => s.ProcessingType).
                Include(s => s.Branch).
                Include(s=>s.StationStatus).
                Include(s=>s.ProcessingSystem).ToList();
            var mappingData = mapper.Map<IEnumerable<StationViewModel>>(stations);
            return View(mappingData);
        }

        [HttpGet]
        public IActionResult Create() { 

            ViewBag.Branches = db.Branches.OrderBy(b=>b.Name).Select(b=> new SelectListItem { Value= b.Id.ToString() , Text=b.Name }).ToList();
            ViewBag.ProcessingSystem = db.ProcessingSystems.OrderBy(b => b.Name).Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name }).ToList();
            ViewBag.ProcessingType = db.ProcessingTypes.OrderBy(b => b.Name).Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name }).ToList();
            ViewBag.StationStatus = db.StationStatuses.OrderBy(b => b.Name).Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name }).ToList();
            ViewBag.SanitaryDrain = db.SanitaryDrain.OrderBy(b => b.Name).Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name }).ToList();
            return View();
        
        }

        [HttpPost]
        public IActionResult Create(CreateStationViewModel mdl)
        {
            return RedirectToAction("Index");

        }
    }
}

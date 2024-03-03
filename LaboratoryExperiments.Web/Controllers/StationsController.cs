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
            if (!ModelState.IsValid)
                return BadRequest();
            var entity = mapper.Map<Station>(mdl);
            db.Stations.Add(entity);
            db.SaveChanges();
            return Ok("station saved successfully");           
        }
        public IActionResult AllowItem(CreateStationViewModel model)
        {
            var station = db.Stations.SingleOrDefault(c => c.Name == model.Name);
            var isAllowed = station is null || station.Id.Equals(model.Id);
            return Json(isAllowed);
        }

        public IActionResult Delete(int id)
        {
            var station = db.Stations.Find(id);
            db.Stations.Remove(station);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Details(int id)
        {
            var station = db.Stations.Include(s => s.SanitaryDrain).
                Include(s => s.ProcessingType).
                Include(s => s.Branch).
                Include(s => s.StationStatus).
                Include(s => s.ProcessingSystem).SingleOrDefault(s=>s.Id==id);
            var mappingData = mapper.Map<StationViewModel>(station);
            return View(mappingData);
        }

        public IActionResult GetStationsByBranchId(int id)
        {
            var stations = db.Stations.Where(s => s.BranchId == id).Select(s => new SelectListItem {Value=s.Id.ToString() ,Text=s.Name });
            return Json(stations);

        }
    }
}

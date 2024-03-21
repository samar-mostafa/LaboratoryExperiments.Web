using AspNetCore.Reporting;
using AspNetCore.Reporting.ReportExecutionService;
using AutoMapper;
using LaboratoryExperiments.Web.Data;
using LaboratoryExperiments.Web.Data.DomainModels;
using LaboratoryExperiments.Web.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq.Dynamic.Core;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LaboratoryExperiments.Web.Controllers
{
    [Authorize]
    public class TestsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment webHostEnvironment;
        public TestsController(ApplicationDbContext db, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            this.db = db;
            this.mapper = mapper;
            this.webHostEnvironment = webHostEnvironment;
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

            if ((model.In_Eff == false || model.In_Eff == true) && (experiment.InffleuntValue == null || experiment.EffleuntValue == null))
                model.Result = true;
            else if (model.In_Eff == false && experiment.InffleuntValueTo != null)
                model.Result = model.EnteredValue >= experiment.InffleuntValue && model.EnteredValue <= experiment.InffleuntValueTo;
            else if (model.In_Eff == false && experiment.InffleuntValueTo is null)
                model.Result = experiment.InffleuntValue >= model.EnteredValue;
            else if (model.In_Eff == true && experiment.EffleuntValueTo != null)
                model.Result = model.EnteredValue >= experiment.EffleuntValue && model.EnteredValue <= experiment.EffleuntValueTo;
            else if (model.In_Eff == true && experiment.EffleuntValueTo is null)
                model.Result = experiment.EffleuntValue >= model.EnteredValue;

            var entity = mapper.Map<Test>(model);
            db.Tests.Add(entity);
            db.SaveChanges();

            var res = model.Result ? "Identical" : "Not matching";
            return Ok(res);
        }

        public IActionResult GetFilterForReport()
        {
            ViewBag.Branchs = db.Branches.OrderBy(b => b.Name).Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name }).ToList();
            ViewBag.Stations = db.Stations.OrderBy(b => b.Name).Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name }).ToList();
            ViewBag.Experiments = db.Experiments.OrderBy(b => b.Name).Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name }).ToList(); 
            ViewBag.ExperimentTypes = db.ExperimentTypes.OrderBy(b => b.Name).Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name }).ToList();
            return View();
        }
        public IQueryable<Test> getData(FilterByViewModel mdl)
        {
            var entities = db.Tests.Include(t => t.Experiment).ThenInclude(e => e.ExperimentType)
              .Include(t => t.Station).ThenInclude(s => s.Branch)
               .Include(t => t.Station).ThenInclude(s => s.SanitaryDrain).Where(t =>
               (t.ExperimentId == mdl.ExperimentId || mdl.ExperimentId == null) &&
               (t.StationId == mdl.StationId || mdl.StationId == null) &&
               (t.Station.BranchId == mdl.BranchId || mdl.BranchId == null) &&
               (t.Experiment.ExperimentTypeId == mdl.ExperimentTypeId || mdl.ExperimentTypeId == null) &&
               (t.Date == mdl.Date || mdl.Date == null));
            return entities;
        }
        public IActionResult GetFilteredData(FilterByViewModel mdl)
        {
            var entities = getData(mdl);
            var pageSize = int.Parse(Request.Form["length"]);
            var skip = int.Parse(Request.Form["start"]);

            var sortingValue = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"], "][name]")];
            var sortDirection = Request.Form["order[0][dir]"];


            entities = entities.OrderBy(string.Concat(sortingValue, " ", sortDirection));

            var data = entities.Skip(skip).Take(pageSize).ToList();
            var mappedData = mapper.Map<IEnumerable<TestViewModel>>(data);
            var recordsTotal = entities.Count();
            var jsonData = new { recordsFiltered = recordsTotal, recordsTotal, data= mappedData };
            return Ok(jsonData);
        }

        [HttpGet]
        public IActionResult FilterByStationAndDate()
        {
            ViewBag.Branchs = db.Branches.OrderBy(b => b.Name).Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name }).ToList();
            ViewBag.Stations = db.Stations.OrderBy(b => b.Name).Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name }).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult FilterByStationAndDate(FilterByStationAndDateViewModel mdl)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);
            var entities = db.Tests.Include(t => t.Experiment).ThenInclude(e => e.ExperimentType).
                Include(t => t.Station).ThenInclude(s => s.Branch)
               .Include(t => t.Station).ThenInclude(s => s.SanitaryDrain).Where(t =>              
               (t.StationId == mdl.StationId ) &&
               (t.Station.BranchId == mdl.BranchId || mdl.BranchId == null) &&
               (t.Date == mdl.Date));
            var mappedData = mapper.Map<IEnumerable<FilteredTestViewModel>>(entities);
            string path = $"{webHostEnvironment.WebRootPath}\\Reports\\FilterByStationAndDate.rdlc";
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("DataSet1", mappedData);
            var report = localReport.Execute(RenderType.Pdf, 1, null, "");
            return File(report.MainStream, "application/pdf");
        }

            [HttpPost]
        public IActionResult ExportToPdf(FilterByViewModel mdl)
        {
            var entities = getData(mdl);
            var mappedData = mapper.Map<IEnumerable<FilteredTestViewModel>>(entities);
            string path = $"{webHostEnvironment.WebRootPath}\\Reports\\FilteredTests.rdlc";
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("DataSet1", mappedData);
            var report = localReport.Execute(RenderType.Pdf, 1, null, "");
            return File(report.MainStream, "application/pdf");
           
           
        }
        public IActionResult ExportToExcel(FilterByViewModel mdl)
        {
            var entities = getData(mdl);
            var mappedData = mapper.Map<IEnumerable<FilteredTestViewModel>>(entities);
            string path = $"{webHostEnvironment.WebRootPath}\\Reports\\FilteredTests.rdlc";
            LocalReport localReport = new LocalReport(path);
            localReport.AddDataSource("DataSet1", mappedData);           
            var report= localReport.Execute(RenderType.Excel, 1, null, "");
            return File(report.MainStream, "application/vnd.ms-excel");
        }
    }
}

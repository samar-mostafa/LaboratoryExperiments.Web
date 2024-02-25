using Microsoft.AspNetCore.Mvc;

namespace LaboratoryExperiments.Web.Controllers
{
    public class TestsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

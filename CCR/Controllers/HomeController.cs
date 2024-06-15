using CCR.Models;
using CCR.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CCR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IComprehensiveServices comprehensiveServices;

        public HomeController(ILogger<HomeController> logger, IComprehensiveServices comprehensiveServices)
        {
            _logger = logger;
            this.comprehensiveServices = comprehensiveServices;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [ActionName("Comprehensive")]
        public IActionResult UploadComprehensive()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Comprehensive")]
        public IActionResult UploadComprehensive(IFormFile file)
        {
            var comp = comprehensiveServices.ExtractComprehensive(file);
            return View(comp);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

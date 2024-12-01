using System.Diagnostics;
using JourneyHubWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace JourneyHubWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly JourneyHubContext JourneyContext; 

        public HomeController(ILogger<HomeController> logger,JourneyHubContext context)
        {
            _logger = logger;
           JourneyContext = context;
        }

        public IActionResult Index()
        {
            return View();
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

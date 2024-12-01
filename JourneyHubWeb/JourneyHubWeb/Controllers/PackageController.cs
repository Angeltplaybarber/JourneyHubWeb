using Microsoft.AspNetCore.Mvc;
using JourneyHubWeb.Models;

namespace JourneyHubWeb.Controllers
{
    public class PackageController : Controller
    {
        JourneyHubContext _db;
        public PackageController(JourneyHubContext journeyHubContext)
        {
            _db = journeyHubContext;
        }

        public IActionResult PackageList()
        {
            return View();
        }
        public IActionResult GetList()
        {

            var client = _db.Packages.ToList();
            return Ok(client);

        }
    }
}


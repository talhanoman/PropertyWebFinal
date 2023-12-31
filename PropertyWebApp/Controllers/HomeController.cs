using Microsoft.AspNetCore.Mvc;
using PropertyWebApp.Data;
using PropertyWebApp.Models;
using System.Diagnostics;

namespace PropertyWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Fetch properties from the database
            var properties = _context.Properties.ToList();

            // Pass the list of properties to the view
            return View(properties);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult PropertyDetails(int id)
        {
            var property = _context.Properties.FirstOrDefault(p => p.Id == id);

            if (property == null)
            {
                return NotFound(); // Return a 404 Not Found if the property is not found
            }

            return View(property);
        }
    }
}
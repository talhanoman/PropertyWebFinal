using Microsoft.AspNetCore.Mvc;

namespace PropertyWebApp.Controllers
{
    public class PropertyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

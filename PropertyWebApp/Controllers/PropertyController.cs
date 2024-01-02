using Microsoft.AspNetCore.Mvc;
using PropertyWebApp.Data;
using PropertyWebApp.Models;
namespace PropertyWebApp.Controllers
{
    public class PropertyController : Controller
    {

        private readonly ApplicationDbContext _context;

        public PropertyController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Delete(int id)
        {
            var property = _context.Properties.Find(id);

            if (property == null)
            {
                return NotFound();
            }

            _context.Properties.Remove(property);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


        // GET: Property/Edit/5
        public IActionResult Edit(int id)
        {
            var property = _context.Properties.Find(id);

            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }


        // POST: Property/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,OwnerId,Address,Price,SquareFootage,Bedrooms,PropertyType,Description")] Property property)
        {
            Console.WriteLine($"ID: {id}, Property: {property}");

            if (id != property.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(property);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // Log ModelState errors
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine($"Error: {error.ErrorMessage}");
            }

            return View(property);
        }
    }
}

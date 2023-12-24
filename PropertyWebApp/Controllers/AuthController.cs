using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyWebApp.Data;
using PropertyWebApp.Models;

namespace PropertyWebApp.Controllers
{
    public class AuthController : Controller
    {

        private readonly ApplicationDbContext _context;

        
        public AuthController(ApplicationDbContext context)
        {
               _context = context;
        }

               
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User model)
        {
            if (ModelState.IsValid)
            {
                // Check if the email is unique
                if (await IsEmailUnique(model.Email))
                {
                    // Create a new user
                    var newUser = new User
                    {
                        Email = model.Email,
                        Password = model.Password // Note: You should hash and salt the password for security
                        // Other properties like CreatedAt will be set automatically
                    };

                    // Add user to the database
                    _context.Users.Add(newUser);
                    await _context.SaveChangesAsync();

                    // Redirect to login or some other page
                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    ModelState.AddModelError("Email", "Email is already in use.");
                }
            }

            // If we reach here, something failed, return to the registration page with errors
            return View(model);
        }

        // Helper method to check if the email is unique
        private async Task<bool> IsEmailUnique(string email)
        {
            return await _context.Users.AllAsync(u => u.Email != email);
        }
    }
}

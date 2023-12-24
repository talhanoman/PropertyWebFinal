using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyWebApp.Data;
using PropertyWebApp.Models;
using BCryptNet = BCrypt.Net.BCrypt;

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
                    string hashedPassword = BCryptNet.HashPassword(model.Password);
                    // Create a new user
                    var newUser = new User
                    {
                        Email = model.Email,
                        Password = hashedPassword                         
                    };

                    // Add user to the database
                    _context.Users.Add(newUser);
                    await _context.SaveChangesAsync();

                    // Redirect to login or some other page
                    return RedirectToAction("Index", "Home");
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



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the user by email
                var user = _context.Users.SingleOrDefault(u => u.Email == model.Email);

                if (user != null && BCryptNet.Verify(model.Password, user.Password))
                {
                    // You can implement your authentication logic here (e.g., setting a cookie or a session variable)
                    HttpContext.Session.SetInt32("UserId", user.Id);
                    // For simplicity, let's assume a successful login redirects to the home page
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Invalid email or password
                    ModelState.AddModelError(string.Empty, "Invalid email or password");
                }
            }

            // If we reach here, something failed, return to the login page with errors
            return View(model);
        }
    }
}

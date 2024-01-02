using Microsoft.AspNetCore.Mvc;
using PropertyWebApp.Data;
using PropertyWebApp.Models;
using System.Security.Claims;

public class UserProfileController : Controller
{
    private readonly ApplicationDbContext _context;

    public UserProfileController(ApplicationDbContext context)
    {
        _context = context;
    }

    private int? GetUserId()
    {
        // Check if the user is authenticated
        if (User.Identity.IsAuthenticated)
        {
            // Retrieve the user's ID from the claims
            var userIdClaim = User.FindFirst("UserId");

            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                return userId;
            }
        }

        // If the user is not authenticated, return null
        return null;
    }



    // GET: UserProfile
    public IActionResult Index(int? userId)
    {
        int? currentUserId = userId ?? GetUserId();

        if (!currentUserId.HasValue)
        {
            // Redirect to the login page if the user ID is not available
            return RedirectToAction("Login", "Auth");
        }

        var userProfile = _context.UserProfiles.FirstOrDefault(u => u.UserId == currentUserId.Value);

        if (userProfile == null)
        {
            return NotFound();
        }

        return View(userProfile);
    }


    public IActionResult Edit()
    {
        int? userId = GetUserId();

        if (!userId.HasValue)
        {
            // If the user is not authenticated, redirect to the login page
            return RedirectToAction("Login", "Auth");
        }

        var userProfile = _context.UserProfiles.FirstOrDefault(u => u.UserId == userId.Value);

        if (userProfile == null)
        {
            return NotFound();
        }

        return View(userProfile);
    }



}

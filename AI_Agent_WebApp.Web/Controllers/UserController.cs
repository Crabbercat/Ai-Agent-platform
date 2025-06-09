using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace AI_Agent_WebApp.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly Data.ApplicationDbContext _context;
        public UserController(IUserService userService, Data.ApplicationDbContext context) { _userService = userService; _context = context; }
        public IActionResult Profile() => View("Profile");
        public IActionResult EditProfile() => View("EditProfile");
        public IActionResult UpdatePassword() => View("UpdatePassword");
        public IActionResult Login() => View("Login");
        public IActionResult Register() => View("Register");
        public IActionResult Settings()
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null || !int.TryParse(userIdClaim, out int userId))
                return RedirectToAction("Login", "Auth");
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null) return NotFound();
            ViewBag.IsSupplier = user.Role == "Supplier";
            return View("~/Views/User/UserProfile.cshtml", user);
        }
        [HttpPost]
        public IActionResult EditProfile([FromForm] User user)
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null || !int.TryParse(userIdClaim, out int userId))
                return RedirectToAction("Login", "Auth");
            var existing = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (existing == null) return NotFound();
            existing.FullName = user.FullName;
            existing.Email = user.Email;
            _context.Users.Update(existing);
            _context.SaveChanges();
            return RedirectToAction("Settings");
        }
        [HttpPost]
        public IActionResult EditCompany([FromForm] AI_Agent_WebApp.Models.Entities.Supplier supplier)
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null || !int.TryParse(userIdClaim, out int userId))
                return RedirectToAction("Login", "Auth");
            var existing = _context.Users.OfType<AI_Agent_WebApp.Models.Entities.Supplier>().FirstOrDefault(s => s.Id == userId);
            if (existing == null) return NotFound();
            existing.CompanyName = supplier.CompanyName;
            existing.CompanyWebsite = supplier.CompanyWebsite;
            _context.Users.Update(existing);
            _context.SaveChanges();
            return RedirectToAction("Settings");
        }
        [HttpPost]
        public IActionResult ChangePassword(string CurrentPassword, string NewPassword, string ConfirmPassword)
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null || !int.TryParse(userIdClaim, out int userId))
                return RedirectToAction("Login", "Auth");
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null) return NotFound();
            if (NewPassword != ConfirmPassword)
            {
                TempData["ErrorMessage"] = "New password and confirmation do not match.";
                return RedirectToAction("Settings");
            }
            if (!AI_Agent_WebApp.Services.Implementations.PasswordHasher.VerifyPassword(CurrentPassword, user.PasswordHash))
            {
                TempData["ErrorMessage"] = "Current password is incorrect.";
                return RedirectToAction("Settings");
            }
            user.PasswordHash = AI_Agent_WebApp.Services.Implementations.PasswordHasher.HashPassword(NewPassword);
            _context.Users.Update(user);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Password changed successfully.";
            return RedirectToAction("Settings");
        }
    }
}

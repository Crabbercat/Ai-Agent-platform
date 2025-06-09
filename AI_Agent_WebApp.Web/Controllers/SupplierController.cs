using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace AI_Agent_WebApp.Controllers
{
    [Authorize]
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;
        private readonly Data.ApplicationDbContext _context;
        public SupplierController(ISupplierService supplierService, Data.ApplicationDbContext context) 
        { 
            _supplierService = supplierService; 
            _context = context; 
        }
        public IActionResult Profile() => View(); // Có thể truyền model nếu cần
        public IActionResult EditProfile() => View();
        public IActionResult Register() => View("RegisterSupplier");
        public IActionResult Settings()
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null || !int.TryParse(userIdClaim, out int userId))
                return RedirectToAction("Login", "Auth");
            var supplier = _context.Users.OfType<Supplier>().FirstOrDefault(s => s.Id == userId);
            if (supplier == null) return NotFound();
            ViewBag.IsSupplier = true;
            return View("~/Views/User/UserProfile.cshtml", supplier);
        }
        [HttpPost]
        public IActionResult EditProfile([FromForm] Supplier supplier)
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null || !int.TryParse(userIdClaim, out int userId))
                return RedirectToAction("Login", "Auth");
            var existing = _context.Users.OfType<Supplier>().FirstOrDefault(s => s.Id == userId);
            if (existing == null) return NotFound();
            existing.FullName = supplier.FullName;
            existing.Email = supplier.Email;
            _context.Users.Update(existing);
            _context.SaveChanges();
            return RedirectToAction("Settings");
        }
        [HttpPost]
        public IActionResult EditCompany([FromForm] Supplier supplier)
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null || !int.TryParse(userIdClaim, out int userId))
                return RedirectToAction("Login", "Auth");
            var existing = _context.Users.OfType<Supplier>().FirstOrDefault(s => s.Id == userId);
            if (existing == null) return NotFound();
            existing.CompanyName = supplier.CompanyName;
            existing.CompanyWebsite = supplier.CompanyWebsite;
            _context.Users.Update(existing);
            _context.SaveChanges();
            return RedirectToAction("Settings");
        }
    }
}

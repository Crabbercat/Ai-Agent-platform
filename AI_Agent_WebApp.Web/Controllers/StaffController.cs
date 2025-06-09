using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AI_Agent_WebApp.Controllers
{
    public class StaffController : Controller
    {
        private readonly IStaffService _staffService;
        private readonly ISupplierService _supplierService;
        public StaffController(IStaffService staffService, ISupplierService supplierService) 
        { 
            _staffService = staffService; 
            _supplierService = supplierService;
        }
        public IActionResult ManageSuppliers() => View("SupplierList");
        public IActionResult Statistics() => View("Statistics", _staffService.GetStatistics());
        public IActionResult Profile() => View();
        public IActionResult EditProfile() => View();
        [HttpPost]
        public IActionResult EditProfile(Staff staff) { /* update logic */ return RedirectToAction("Profile"); }
        public IActionResult UpdatePassword() => View();
        [HttpPost]
        public IActionResult UpdatePassword(int id, string newPasswordHash) { /* update logic */ return RedirectToAction("Profile"); }

        // List all suppliers
        public IActionResult SupplierList()
        {
            var suppliers = _supplierService.GetAllSuppliers().ToList();
            return View("SupplierList", suppliers);
        }

        // View supplier profile (read-only)
        public IActionResult SupplierProfile(int id)
        {
            var supplier = _supplierService.GetSupplierById(id);
            if (supplier == null) return NotFound();
            ViewBag.IsSupplier = true;
            ViewBag.ReadOnly = true;
            return View("~/Views/User/UserProfile.cshtml", supplier);
        }

        // Toggle supplier status (activate/unactive)
        [HttpPost]
        public IActionResult ToggleSupplierStatus(int id)
        {
            _supplierService.ToggleStatus(id);
            return RedirectToAction("SupplierList");
        }
    }
}

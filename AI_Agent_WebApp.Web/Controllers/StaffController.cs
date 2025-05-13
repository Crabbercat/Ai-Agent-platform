using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AI_Agent_WebApp.Controllers
{
    public class StaffController : Controller
    {
        private readonly IStaffService _staffService;
        public StaffController(IStaffService staffService) { _staffService = staffService; }
        public IActionResult ManageSuppliers() => View("SupplierList");
        public IActionResult ToggleSupplierStatus(int id) { /* logic */ return RedirectToAction("ManageSuppliers"); }
        public IActionResult Statistics() => View("Statistics", _staffService.GetStatistics());
        public IActionResult Profile() => View();
        public IActionResult EditProfile() => View();
        [HttpPost]
        public IActionResult EditProfile(Staff staff) { /* update logic */ return RedirectToAction("Profile"); }
        public IActionResult UpdatePassword() => View();
        [HttpPost]
        public IActionResult UpdatePassword(int id, string newPasswordHash) { /* update logic */ return RedirectToAction("Profile"); }
    }
}

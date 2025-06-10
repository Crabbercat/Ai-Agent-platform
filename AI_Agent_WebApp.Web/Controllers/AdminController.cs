using AI_Agent_WebApp.Data;
using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AI_Agent_WebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IStaffService _staffService;
        private readonly ApplicationDbContext _context;
        public AdminController(IStaffService staffService, ApplicationDbContext context)
        {
            _staffService = staffService;
            _context = context;
        }

        // List all staff
        public IActionResult StaffList()
        {
            var staffList = _staffService.GetAllStaff().ToList();
            return View("StaffList", staffList);
        }

        // Create staff (GET)
        public IActionResult CreateStaff()
        {
            return View();
        }

        // Create staff (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateStaff(Staff model, string Password)
        {
            if (string.IsNullOrWhiteSpace(Password))
            {
                ModelState.AddModelError("Password", "Password is required.");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                // Hash mật khẩu trước khi lưu
                model.PasswordHash = AI_Agent_WebApp.Services.Implementations.PasswordHasher.HashPassword(Password);
                model.CreatedAt = DateTime.Now;
                model.Role = "Staff";
                try
                {
                    _staffService.AddStaff(model);
                    TempData["SuccessMessage"] = "Staff account created successfully.";
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Lỗi khi lưu staff: " + ex.Message);
                }
            }
            return View(model);
        }

        // Edit staff (GET)
        public IActionResult EditStaff(int id)
        {
            var staff = _staffService.GetStaffById(id);
            if (staff == null) return NotFound();
            return View(staff);
        }

        // Edit staff (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditStaff(Staff staff)
        {
            if (ModelState.IsValid)
            {
                var result = _staffService.UpdateStaff(staff);
                if (result)
                    return RedirectToAction("StaffList");
                ModelState.AddModelError("", "Username or Email already exists.");
            }
            return View(staff);
        }

        // View staff profile (read-only)
        public IActionResult StaffProfile(int id)
        {
            var staff = _staffService.GetStaffById(id);
            if (staff == null) return NotFound();
            ViewBag.IsStaff = true;
            ViewBag.ReadOnly = true;
            return View("~/Views/User/UserProfile.cshtml", staff);
        }

        // Toggle staff status (activate/unactive)
        [HttpPost]
        public IActionResult ToggleStaffStatus(int id)
        {
            _staffService.ToggleStatus(id);
            return RedirectToAction("StaffList");
        }

        // Delete staff (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteStaff(int id)
        {
            _staffService.DeleteStaff(id);
            return RedirectToAction("StaffList");
        }

        // Thống kê hệ thống
        public IActionResult SystemStatistics()
        {
            var context = _context;
            var totalAgents = context.Agents.Count();
            var totalSuppliers = context.Users.Count(u => u.Role == "Supplier");
            var totalUsers = context.Users.Count(u => u.Role == "User");
            var agentsByCategory = context.Categories
                .Select(c => new AI_Agent_WebApp.Models.ViewModels.AgentsByCategory
                {
                    CategoryName = c.Name,
                    Count = context.Agents.Count(a => a.CategoryId == c.Id)
                })
                .ToList();
            var vm = new AI_Agent_WebApp.Models.ViewModels.SystemStatisticsViewModel
            {
                TotalAgents = totalAgents,
                TotalSuppliers = totalSuppliers,
                TotalUsers = totalUsers,
                AgentsByCategory = agentsByCategory
            };
            return View("SystemStatistics", vm);
        }
    }
}

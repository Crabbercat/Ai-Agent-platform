using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AI_Agent_WebApp.Web.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierService) { _supplierService = supplierService; }
        public IActionResult Profile() => View(); // Có thể truyền model nếu cần
        public IActionResult EditProfile() => View();
        [HttpPost]
        public IActionResult EditProfile(Supplier supplier) { _supplierService.UpdateProfile(supplier); return RedirectToAction("Profile"); }
        public IActionResult Register() => View("RegisterSupplier");
    }
}

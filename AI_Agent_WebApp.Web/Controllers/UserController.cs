using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AI_Agent_WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) { _userService = userService; }
        public IActionResult Profile() => View("Profile");
        public IActionResult EditProfile() => View("EditProfile");
        [HttpPost]
        public IActionResult EditProfile(User user) { _userService.UpdateProfile(user); return RedirectToAction("Profile"); }
        public IActionResult UpdatePassword() => View("UpdatePassword");
        [HttpPost]
        public IActionResult UpdatePassword(int id, string newPasswordHash) { _userService.UpdatePassword(id, newPasswordHash); return RedirectToAction("Profile"); }
        public IActionResult Login() => View("Login");
        public IActionResult Register() => View("Register");
    }
}

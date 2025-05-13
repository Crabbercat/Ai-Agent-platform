using Microsoft.AspNetCore.Mvc;
using AI_Agent_WebApp.Models.ViewModels;
using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Repositories.Interfaces;
using AI_Agent_WebApp.Data;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using AI_Agent_WebApp.Services.Implementations;

namespace AI_Agent_WebApp.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ApplicationDbContext _context;

        public AuthController(IUserRepository userRepository, ApplicationDbContext context)
        {
            _userRepository = userRepository;
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _context.Users.FirstOrDefault(u => (u.Username == model.UsernameOrEmail || u.Email == model.UsernameOrEmail));
            if (user == null || !PasswordHasher.VerifyPassword(model.Password, user.PasswordHash))
            {
                ModelState.AddModelError("", "Sai tài khoản hoặc mật khẩu.");
                return View(model);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("role", user.Role),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) // Thêm claim Id
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (_context.Users.Any(u => u.Username == model.Username))
            {
                ModelState.AddModelError("Username", "Tên đăng nhập đã tồn tại.");
                return View(model);
            }

            if (_context.Users.Any(u => u.Email == model.Email))
            {
                ModelState.AddModelError("Email", "Email đã được sử dụng.");
                return View(model);
            }

            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                FullName = model.FullName,
                PasswordHash = PasswordHasher.HashPassword(model.Password),
                Role = "User",
                CreatedAt = DateTime.Now
            };

            _context.Users.Add(user);
            _context.SaveChanges();
            TempData["RegisterSuccess"] = "Đăng ký thành công. Vui lòng đăng nhập.";
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult RegisterSupplier()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterSupplier(RegisterSupplierViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (_context.Users.Any(u => u.Username == model.Username))
            {
                ModelState.AddModelError("Username", "Tên đăng nhập đã tồn tại.");
                return View(model);
            }

            if (_context.Users.Any(u => u.Email == model.Email))
            {
                ModelState.AddModelError("Email", "Email đã được sử dụng.");
                return View(model);
            }

            var supplier = new Supplier
            {
                Username = model.Username,
                Email = model.Email,
                FullName = model.FullName,
                PasswordHash = PasswordHasher.HashPassword(model.Password),
                Role = "Supplier",
                CreatedAt = DateTime.Now,
                CompanyName = model.CompanyName,
                CompanyWebsite = model.CompanyWebsite,
                Status = true
            };

            _context.Users.Add(supplier);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}

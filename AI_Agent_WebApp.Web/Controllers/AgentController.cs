using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Models.ViewModels;
using AI_Agent_WebApp.Services.Interfaces;
using AI_Agent_WebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AI_Agent_WebApp.Controllers
{
    public class AgentController : Controller
    {
        private readonly IAgentService _agentService;
        private readonly ApplicationDbContext _context;
        private readonly IReviewService _reviewService;

        public AgentController(IAgentService agentService, ApplicationDbContext context, IReviewService reviewService)
        {
            _agentService = agentService;
            _context = context;
            _reviewService = reviewService;
        }

        public IActionResult Index()
        {
            var agents = _agentService.GetAllAgents(); // Chỉ lấy agent active cho user thường
            return View("AgentList", agents);
        }

        public IActionResult Details(int id)
        {
            // Đảm bảo load Articles khi lấy agent
            var agent = _context.Agents
                .Include(a => a.Articles)
                .FirstOrDefault(a => a.Id == id);
            if (agent == null)
                return NotFound();
            var reviews = _reviewService.GetReviewsByAgent(id).ToList();
            // Kiểm tra user đã follow chưa
            bool isFollowed = false;
            bool isOwner = false;
            bool isSupplier = false;
            var user = HttpContext.User;
            if (user?.Identity != null && user.Identity.IsAuthenticated)
            {
                var userIdClaim = user.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                if (userIdClaim != null && int.TryParse(userIdClaim, out int userId))
                {
                    isFollowed = _context.Follows.Any(f => f.UserId == userId && f.AgentId == id);
                    // Kiểm tra có phải supplier sở hữu agent không
                    var supplier = _context.Users.FirstOrDefault(s => s.Id == userId && s.Role == "Supplier");
                    isSupplier = supplier != null;
                    isOwner = supplier != null && supplier.Id == agent.SupplierId;
                }
            }
            var vm = new AgentDetailViewModel
            {
                Agent = agent,
                ReviewCount = _agentService.GetReviewCountForAgent(id),
                FollowerCount = _agentService.GetFollowerCountForAgent(id),
                Reviews = reviews,
                IsFollowed = isFollowed,
                IsOwner = isOwner,
                IsSupplier = isSupplier
            };
            return View("AgentDetails", vm);
        }

        // Supplier actions
        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.PaymentTypes = _context.PaymentTypes.ToList();
            return View("CreateAgent");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Models.ViewModels.AgentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var agent = new Agent
                {
                    Name = model.Name,
                    Description = model.Description,
                    CategoryId = model.CategoryId,
                    PaymentTypeId = model.PaymentTypeId,
                    Url = model.Url,
                    CreatedAt = DateTime.Now,
                    IsActive = true
                };
                // Lấy SupplierId từ user đăng nhập
                var user = HttpContext.User;
                var idClaim = user.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
                if (idClaim != null && int.TryParse(idClaim.Value, out int supplierId))
                {
                    agent.SupplierId = supplierId;
                }
                // Xử lý upload ảnh
                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {
                    var fileName = $"{Path.GetFileNameWithoutExtension(model.ImageFile.FileName)}_{DateTime.Now.Ticks}{Path.GetExtension(model.ImageFile.FileName)}";
                    var folderPath = Path.Combine("wwwroot", "images", "agents");
                    Directory.CreateDirectory(folderPath);
                    var fullPath = Path.Combine(folderPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await model.ImageFile.CopyToAsync(stream);
                    }
                    agent.ImagePath = $"/images/agents/{fileName}";
                }
                else
                {
                    agent.ImagePath = "/images/default-agent.png";
                }
                _context.Agents.Add(agent);
                await _context.SaveChangesAsync();
                return RedirectToAction("MyAgents");
            }
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.PaymentTypes = _context.PaymentTypes.ToList();
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var agent = _context.Agents.Find(id);
            if (agent == null) return NotFound();
            var model = new Models.ViewModels.AgentViewModel
            {
                Id = agent.Id,
                Name = agent.Name,
                Description = agent.Description,
                CategoryId = agent.CategoryId,
                PaymentTypeId = agent.PaymentTypeId,
                Url = agent.Url,
                ImagePath = agent.ImagePath
            };
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.PaymentTypes = _context.PaymentTypes.ToList();
            return View("EditAgent", model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Models.ViewModels.AgentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var agent = _context.Agents.Find(model.Id);
                if (agent == null) return NotFound();
                agent.Name = model.Name;
                agent.Description = model.Description;
                agent.CategoryId = model.CategoryId;
                agent.PaymentTypeId = model.PaymentTypeId;
                agent.Url = model.Url;
                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {
                    var fileName = $"agent_{DateTime.Now.Ticks}{Path.GetExtension(model.ImageFile.FileName)}";
                    var folderPath = Path.Combine("wwwroot", "images", "agents");
                    Directory.CreateDirectory(folderPath);
                    var fullPath = Path.Combine(folderPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await model.ImageFile.CopyToAsync(stream);
                    }
                    agent.ImagePath = $"/images/agents/{fileName}";
                }
                // Nếu không upload mới, giữ nguyên ảnh cũ
                _context.Agents.Update(agent);
                await _context.SaveChangesAsync();
                return RedirectToAction("MyAgents");
            }
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.PaymentTypes = _context.PaymentTypes.ToList();
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            _agentService.DeleteAgent(id);
            return RedirectToAction("MyAgents");
        }

        [HttpGet]
        public IActionResult MyAgents()
        {
            var user = HttpContext.User;

            if (user != null && (user.IsInRole("Staff") || (user.FindFirst("role")?.Value ?? "") == "Staff"))
            {
                var agents = _agentService.GetAllAgents(includeInactive: true);
                return View("MyAgents", agents);
            }
            else if (user != null && (user.IsInRole("Supplier") || (user.FindFirst("role")?.Value ?? "") == "Supplier"))
            {
                var idClaim = user.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
                if (idClaim != null && int.TryParse(idClaim.Value, out int supplierId))
                {
                    var agents = _agentService.GetAllAgents(includeInactive: true, supplierId: supplierId);
                    return View("MyAgents", agents);
                }
                return View("MyAgents", new List<AI_Agent_WebApp.Models.Entities.Agent>());
            }
            TempData["ErrorMessage"] = "Bạn không có quyền truy cập trang này.";
            return RedirectToAction("Index", "Home");
        }

        // Registered User actions
        public IActionResult Follow(int id)
        {
            var user = HttpContext.User;
            if (user?.Identity == null || !user.Identity.IsAuthenticated)
            {
                TempData["ErrorMessage"] = "Bạn cần đăng nhập để theo dõi agent.";
                return RedirectToAction("Login", "Auth");
            }
            var userIdClaim = user.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                TempData["ErrorMessage"] = "Không xác định được người dùng.";
                return RedirectToAction("Details", new { id });
            }
            // Kiểm tra đã follow chưa
            var existed = _context.Follows.FirstOrDefault(f => f.UserId == userId && f.AgentId == id);
            if (existed != null)
            {
                TempData["ErrorMessage"] = "Bạn đã theo dõi agent này rồi.";
                return RedirectToAction("Details", new { id });
            }
            // Thêm mới follow
            var follow = new AI_Agent_WebApp.Models.Entities.Follow
            {
                UserId = userId,
                AgentId = id,
                FollowedAt = DateTime.Now
            };
            _context.Follows.Add(follow);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Đã theo dõi agent thành công.";
            return RedirectToAction("Details", new { id });
        }

        [HttpPost]
        public IActionResult Unfollow(int id)
        {
            var user = HttpContext.User;
            if (user?.Identity == null || !user.Identity.IsAuthenticated)
            {
                TempData["ErrorMessage"] = "Bạn cần đăng nhập để bỏ theo dõi agent.";
                return RedirectToAction("Login", "Auth");
            }
            var userIdClaim = user.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                TempData["ErrorMessage"] = "Không xác định được người dùng.";
                return RedirectToAction("Details", new { id });
            }
            var follow = _context.Follows.FirstOrDefault(f => f.UserId == userId && f.AgentId == id);
            if (follow != null)
            {
                _context.Follows.Remove(follow);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Đã bỏ theo dõi agent.";
            }
            else
            {
                TempData["ErrorMessage"] = "Bạn chưa theo dõi agent này.";
            }
            return RedirectToAction("Details", new { id });
        }

        public IActionResult MyFollowed()
        {
            var user = HttpContext.User;
            if (user?.Identity == null || !user.Identity.IsAuthenticated)
            {
                TempData["ErrorMessage"] = "Bạn cần đăng nhập để xem danh sách agent đã theo dõi.";
                return RedirectToAction("Login", "Auth");
            }
            var userIdClaim = user.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                TempData["ErrorMessage"] = "Không xác định được người dùng.";
                return RedirectToAction("Index", "Home");
            }
            // Lấy danh sách agent mà user đã follow
            var followedAgentIds = _context.Follows.Where(f => f.UserId == userId).Select(f => f.AgentId).ToList();
            var agents = _agentService.GetAllAgents(true).Where(a => followedAgentIds.Contains(a.Id)).ToList();
            return View("FollowedAgents", agents);
        }

        // Staff actions
        public IActionResult ManageAll()
        {
            var agents = _agentService.GetAllAgents(includeInactive: true); // Staff xem được tất cả
            return View("AllAgents", agents);
        }

        [HttpPost]
        public IActionResult ToggleStatus(int id)
        {
            _agentService.ToggleStatus(id);
            return RedirectToAction("ManageAll");
        }

        public IActionResult Search(string? searchTerm, int? categoryId, int? paymentTypeId, int page = 1)
        {
            const int pageSize = 12;
            var allAgents = _agentService.GetAllAgents().ToList(); // Chỉ lấy agent active cho user thường
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                allAgents = allAgents.Where(a => a.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || (a.Description != null && a.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))).ToList();
            }
            if (categoryId.HasValue)
            {
                allAgents = allAgents.Where(a => a.CategoryId == categoryId.Value).ToList();
            }
            if (paymentTypeId.HasValue)
            {
                allAgents = allAgents.Where(a => a.PaymentTypeId == paymentTypeId.Value).ToList();
            }
            allAgents = allAgents.OrderByDescending(a => a.Follows?.Count ?? 0)
                                 .ThenByDescending(a => a.Articles?.Count ?? 0)
                                 .ToList();
            int totalAgents = allAgents.Count;
            int totalPages = (int)Math.Ceiling(totalAgents / (double)pageSize);
            var pagedAgents = allAgents.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var categories = _context.Categories.ToList();
            var paymentTypes = _context.PaymentTypes.ToList();
            var vm = new Models.ViewModels.AgentSearchViewModel
            {
                SearchTerm = searchTerm,
                CategoryId = categoryId,
                PaymentTypeId = paymentTypeId,
                Page = page,
                TotalPages = totalPages,
                Categories = categories,
                PaymentTypes = paymentTypes,
                Agents = pagedAgents
            };
            return View(vm);
        }
    }
}

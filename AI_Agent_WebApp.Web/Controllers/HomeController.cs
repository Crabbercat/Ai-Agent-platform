using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Services.Interfaces;
using AI_Agent_WebApp.Data;
using System.Linq;

namespace AI_Agent_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAgentService _agentService;
        private readonly ApplicationDbContext _context;

        public HomeController(IAgentService agentService, ApplicationDbContext context)
        {
            _agentService = agentService;
            _context = context;
        }

        public IActionResult Index()
        {
            // Lấy tất cả agent, tính số follower và số bài viết cho từng agent
            var agents = _agentService.GetAllAgents().ToList();
            // Sắp xếp theo số lượng follower giảm dần, sau đó đến số lượng bài viết giảm dần
            var sortedAgents = agents
                .OrderByDescending(a => a.Follows?.Count ?? 0)
                .ThenByDescending(a => a.Articles?.Count ?? 0)
                .Take(12)
                .ToList();
            // Set categories for layout footer
            ViewBag.Categories = _context.Categories.ToList();
            return View(sortedAgents);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Xử lý lỗi nếu cần, hoặc trả về view mặc định
            return View();
        }
    }
}

using AI_Agent_WebApp.Data;
using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AI_Agent_WebApp.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ApplicationDbContext _context;
        public ArticleController(IArticleService articleService, ApplicationDbContext context) { _articleService = articleService; _context = context; }
        public IActionResult Index(int agentId) => View("ArticleList", _articleService.GetArticlesByAgent(agentId));
        public IActionResult Details(int id)
        {
            var article = _context.Articles
                .Include(a => a.Agent)
                .Include(a => a.User)
                .FirstOrDefault(a => a.Id == id);
            if (article == null)
                return NotFound();
            return View("ArticleDetails", article);
        }
        public IActionResult Create(int? agentId = null)
        {
            var user = HttpContext.User;
            if (user?.Identity == null || !user.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Auth");
            var userIdClaim = user.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null || !int.TryParse(userIdClaim, out int userId))
                return RedirectToAction("Login", "Auth");
            // Lấy danh sách agent của supplier
            var agents = _context.Agents.Where(a => a.SupplierId == userId).ToList();
            ViewBag.Agents = agents;
            var article = new Article { AgentId = agentId ?? (agents.FirstOrDefault()?.Id ?? 0), UserId = userId, Title = string.Empty };
            return View("CreateArticle", article);
        }

        [HttpPost]
        public IActionResult Create(Article article)
        {
            var user = HttpContext.User;
            if (user?.Identity == null || !user.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Auth");
            var userIdClaim = user.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null || !int.TryParse(userIdClaim, out int userId))
                return RedirectToAction("Login", "Auth");
            var agent = _context.Agents.FirstOrDefault(a => a.Id == article.AgentId && a.SupplierId == userId);
            if (agent == null)
                return Forbid();
            article.UserId = userId;
            article.CreatedAt = DateTime.Now;
            _context.Articles.Add(article);
            _context.SaveChanges();
            return RedirectToAction("MyArticles");
        }

        public IActionResult Edit(int id)
        {
            var user = HttpContext.User;
            if (user?.Identity == null || !user.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Auth");
            var userIdClaim = user.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null || !int.TryParse(userIdClaim, out int userId))
                return RedirectToAction("Login", "Auth");
            var article = _context.Articles.FirstOrDefault(a => a.Id == id);
            if (article == null)
                return NotFound();
            if (article.UserId != userId)
                return Forbid();
            return View("EditArticle", article);
        }

        [HttpPost]
        public IActionResult Edit(Article article)
        {
            var user = HttpContext.User;
            if (user?.Identity == null || !user.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Auth");
            var userIdClaim = user.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null || !int.TryParse(userIdClaim, out int userId))
                return RedirectToAction("Login", "Auth");
            var existing = _context.Articles.FirstOrDefault(a => a.Id == article.Id);
            if (existing == null)
                return NotFound();
            if (existing.UserId != userId)
                return Forbid();
            existing.Title = article.Title;
            existing.Content = article.Content;
            _context.Articles.Update(existing);
            _context.SaveChanges();
            return RedirectToAction("MyArticles");
        }

        public IActionResult Delete(int id)
        {
            var user = HttpContext.User;
            if (user?.Identity == null || !user.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Auth");
            var userIdClaim = user.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null || !int.TryParse(userIdClaim, out int userId))
                return RedirectToAction("Login", "Auth");
            var article = _context.Articles.FirstOrDefault(a => a.Id == id);
            if (article == null)
                return NotFound();
            if (article.UserId != userId)
                return Forbid();
            _context.Articles.Remove(article);
            _context.SaveChanges();
            return RedirectToAction("MyArticles");
        }

        public IActionResult MyArticles(int? agentId = null)
        {
            var user = HttpContext.User;
            if (user?.Identity == null || !user.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Auth");
            var userIdClaim = user.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null || !int.TryParse(userIdClaim, out int userId))
                return RedirectToAction("Login", "Auth");
            var agents = _context.Agents.Where(a => a.SupplierId == userId).ToList();
            ViewBag.Agents = agents;
            ViewBag.SelectedAgentId = agentId;
            var articles = _context.Articles
                .Where(a => a.UserId == userId && (agentId == null || a.AgentId == agentId))
                .OrderByDescending(a => a.CreatedAt)
                .ToList();
            return View("MyArticles", articles);
        }

        public IActionResult List(int agentId)
        {
            var agent = _context.Agents.FirstOrDefault(a => a.Id == agentId);
            if (agent == null) return NotFound();
            var articles = _context.Articles.Where(a => a.AgentId == agentId).OrderByDescending(a => a.CreatedAt).ToList();
            ViewBag.Agent = agent;
            return View("ArticleList", articles);
        }
    }
}

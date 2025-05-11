using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AI_Agent_WebApp.Web.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        public ArticleController(IArticleService articleService) { _articleService = articleService; }
        public IActionResult Index(int agentId) => View("ArticleList", _articleService.GetArticlesByAgent(agentId));
        public IActionResult Details(int id) => View("ArticleDetails"); // Cần truyền model nếu có
        public IActionResult Create(int agentId) => View("CreateArticle", new Article { AgentId = agentId, Title = string.Empty });
        [HttpPost]
        public IActionResult Create(Article article) { _articleService.CreateArticle(article); return RedirectToAction("MyArticles"); }
        public IActionResult Edit(int id) => View("EditArticle"); // Cần truyền model nếu có
        [HttpPost]
        public IActionResult Edit(Article article) { _articleService.UpdateArticle(article); return RedirectToAction("MyArticles"); }
        public IActionResult Delete(int id) { _articleService.DeleteArticle(id); return RedirectToAction("MyArticles"); }
        public IActionResult MyArticles() => View("MyArticles"); // Cần truyền model nếu có
    }
}

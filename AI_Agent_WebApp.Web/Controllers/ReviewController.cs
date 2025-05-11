using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AI_Agent_WebApp.Web.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService) { _reviewService = reviewService; }
        public IActionResult ListByAgent(int agentId) => View("_ReviewList", _reviewService.GetReviewsByAgent(agentId));
        public IActionResult Create(int agentId) => View("CreateReview", new Review { AgentId = agentId });
        [HttpPost]
        public IActionResult Post(Review review) { _reviewService.CreateReview(review); return RedirectToAction("ListByAgent", new { agentId = review.AgentId }); }
    }
}

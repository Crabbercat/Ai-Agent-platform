using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace AI_Agent_WebApp.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService) { _reviewService = reviewService; }
        public IActionResult ListByAgent(int agentId) => View("_ReviewList", _reviewService.GetReviewsByAgent(agentId));
        public IActionResult Create(int agentId) => View("CreateReview", new Review { AgentId = agentId });
        [HttpPost]
        [Authorize]
        public IActionResult Post(Review review)
        {
            // Lấy UserId từ Claims
            if (User.Identity?.IsAuthenticated == true)
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
                if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
                {
                    review.UserId = userId;
                    // Kiểm tra nếu user đã đánh giá agent này trong 1 tháng gần nhất
                    var now = DateTime.Now;
                    var lastReview = _reviewService.GetReviewsByAgent(review.AgentId)
                        .FirstOrDefault(r => r.UserId == userId && r.CreatedAt > now.AddMonths(-1));
                    if (lastReview != null)
                    {
                        TempData["ReviewError"] = $"Bạn đã đánh giá Agent này vào ngày {lastReview.CreatedAt:dd/MM/yyyy}. Bạn chỉ được đánh giá lại sau 1 tháng.";
                        return RedirectToAction("Details", "Agent", new { id = review.AgentId });
                    }
                }
            }
            review.CreatedAt = DateTime.Now;
            _reviewService.CreateReview(review);
            TempData["ReviewSuccess"] = "Đánh giá của bạn đã được gửi thành công!";
            return RedirectToAction("Details", "Agent", new { id = review.AgentId });
        }
    }
}

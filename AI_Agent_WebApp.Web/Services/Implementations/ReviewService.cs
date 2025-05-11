using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Repositories.Interfaces;
using AI_Agent_WebApp.Services.Interfaces;
using System.Collections.Generic;

namespace AI_Agent_WebApp.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _repo;
        public ReviewService(IReviewRepository repo) { _repo = repo; }
        public IEnumerable<Review> GetReviewsByAgent(int agentId) => _repo.GetByAgentId(agentId);
        public void CreateReview(Review review) => _repo.Create(review);
    }
}

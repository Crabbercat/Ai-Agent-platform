using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Repositories.Interfaces;

namespace AI_Agent_WebApp.Repositories.Implementations
{
    public class ReviewRepository : IReviewRepository
    {
        public IEnumerable<Review> GetByAgentId(int agentId) => throw new NotImplementedException();
        public void Create(Review review) => throw new NotImplementedException();
    }
}

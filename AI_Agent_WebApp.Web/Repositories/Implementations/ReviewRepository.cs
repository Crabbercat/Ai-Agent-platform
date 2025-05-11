using AI_Agent_WebApp.Data;
using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AI_Agent_WebApp.Repositories.Implementations
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _context;
        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Review> GetByAgentId(int agentId) => _context.Reviews
            .Include(r => r.Agent)
            .Include(r => r.User)
            .Where(r => r.AgentId == agentId)
            .ToList();
        public IEnumerable<Review> GetByUserId(int userId) => _context.Reviews
            .Include(r => r.Agent)
            .Include(r => r.User)
            .Where(r => r.UserId == userId)
            .ToList();
        public void Create(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }
    }
}

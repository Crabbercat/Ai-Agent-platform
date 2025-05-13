using AI_Agent_WebApp.Data;
using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AI_Agent_WebApp.Repositories.Implementations
{
    public class AgentRepository : IAgentRepository
    {
        private readonly ApplicationDbContext _context;
        public AgentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Agent> GetAll() => _context.Agents
            .Include(a => a.Supplier)
            .Include(a => a.Category)
            .Include(a => a.PaymentType)
            .Include(a => a.Follows)
            .ToList();
        public Agent GetById(int id) => _context.Agents
            .Include(a => a.Supplier)
            .Include(a => a.Category)
            .Include(a => a.PaymentType)
            .Include(a => a.Follows)
            .FirstOrDefault(a => a.Id == id)!;
        public void Insert(Agent agent)
        {
            _context.Agents.Add(agent);
            _context.SaveChanges();
        }
        public void Update(Agent agent)
        {
            _context.Agents.Update(agent);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var agent = _context.Agents.Find(id);
            if (agent != null)
            {
                _context.Agents.Remove(agent);
                _context.SaveChanges();
            }
        }
        public void ToggleStatus(int id)
        {
            var agent = _context.Agents.Find(id);
            if (agent != null)
            {
                agent.IsActive = !agent.IsActive;
                _context.SaveChanges();
            }
        }
        public int GetReviewCountForAgent(int agentId)
        {
            return _context.Reviews.Count(r => r.AgentId == agentId);
        }
        public int GetFollowerCountForAgent(int agentId)
        {
            return _context.Follows.Count(f => f.AgentId == agentId);
        }
    }
}

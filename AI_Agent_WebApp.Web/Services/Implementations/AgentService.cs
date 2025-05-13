using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Repositories.Interfaces;
using AI_Agent_WebApp.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AI_Agent_WebApp.Services.Implementations
{
    public class AgentService : IAgentService
    {
        private readonly IAgentRepository _repo;
        public AgentService(IAgentRepository repo) { _repo = repo; }
        public IEnumerable<Agent> GetAllAgents(bool includeInactive = false, int? supplierId = null)
        {
            var agents = _repo.GetAll();
            if (supplierId.HasValue)
                agents = agents.Where(a => a.SupplierId == supplierId.Value).ToList();
            if (!includeInactive)
                agents = agents.Where(a => a.IsActive).ToList();
            return agents;
        }
        public Agent GetAgentById(int id) => _repo.GetById(id);
        public void CreateAgent(Agent agent) => _repo.Insert(agent);
        public void UpdateAgent(Agent agent) => _repo.Update(agent);
        public void DeleteAgent(int id) => _repo.Delete(id);
        public void ToggleStatus(int id) => _repo.ToggleStatus(id);
        public int GetReviewCountForAgent(int agentId) => _repo.GetReviewCountForAgent(agentId);
        public int GetFollowerCountForAgent(int agentId) => _repo.GetFollowerCountForAgent(agentId);
    }
}

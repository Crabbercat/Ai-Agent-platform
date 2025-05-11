using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Repositories.Interfaces;
using AI_Agent_WebApp.Services.Interfaces;
using System.Collections.Generic;

namespace AI_Agent_WebApp.Services.Implementations
{
    public class AgentService : IAgentService
    {
        private readonly IAgentRepository _repo;
        public AgentService(IAgentRepository repo) { _repo = repo; }
        public IEnumerable<Agent> GetAllAgents() => _repo.GetAll();
        public Agent GetAgentById(int id) => _repo.GetById(id);
        public void CreateAgent(Agent agent) => _repo.Insert(agent);
        public void UpdateAgent(Agent agent) => _repo.Update(agent);
        public void DeleteAgent(int id) => _repo.Delete(id);
        public void ToggleStatus(int id) => _repo.ToggleStatus(id);
    }
}

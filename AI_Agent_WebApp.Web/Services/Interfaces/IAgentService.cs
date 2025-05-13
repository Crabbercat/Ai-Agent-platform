using AI_Agent_WebApp.Models.Entities;
using System.Collections.Generic;

namespace AI_Agent_WebApp.Services.Interfaces
{
    public interface IAgentService
    {
        IEnumerable<Agent> GetAllAgents(bool includeInactive = false, int? supplierId = null);
        Agent GetAgentById(int id);
        void CreateAgent(Agent agent);
        void UpdateAgent(Agent agent);
        void DeleteAgent(int id);
        void ToggleStatus(int id);
        int GetReviewCountForAgent(int agentId);
        int GetFollowerCountForAgent(int agentId);
    }
}

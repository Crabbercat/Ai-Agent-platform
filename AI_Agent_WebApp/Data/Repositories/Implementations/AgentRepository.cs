using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Repositories.Interfaces;

namespace AI_Agent_WebApp.Repositories.Implementations
{
    public class AgentRepository : IAgentRepository
    {
        // Cài đặt cụ thể sẽ bổ sung sau khi có database
        public IEnumerable<Agent> GetAll() => throw new NotImplementedException();
        public Agent GetById(int id) => throw new NotImplementedException();
        public void Insert(Agent agent) => throw new NotImplementedException();
        public void Update(Agent agent) => throw new NotImplementedException();
        public void Delete(int id) => throw new NotImplementedException();
        public void ToggleStatus(int id) => throw new NotImplementedException();
    }
}

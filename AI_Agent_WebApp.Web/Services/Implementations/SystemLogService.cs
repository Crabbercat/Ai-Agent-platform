using AI_Agent_WebApp.Repositories.Interfaces;
using AI_Agent_WebApp.Services.Interfaces;

namespace AI_Agent_WebApp.Services.Implementations
{
    public class SystemLogService : ISystemLogService
    {
        private readonly ISystemLogRepository _repo;
        public SystemLogService(ISystemLogRepository repo) { _repo = repo; }
        public void LogAction(string action, int userId) => _repo.LogAction(action, userId);
        public object GetStatistics() => _repo.GetStatistics();
    }
}

using AI_Agent_WebApp.Data;
using AI_Agent_WebApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AI_Agent_WebApp.Repositories.Implementations
{
    public class SystemLogRepository : ISystemLogRepository
    {
        private readonly ApplicationDbContext _context;

        public SystemLogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void LogAction(string action, int userId)
        {
            var log = new Models.Entities.SystemLog
            {
                UserId = userId,
                Action = action,
                Timestamp = DateTime.Now
            };
            _context.SystemLogs.Add(log);
            _context.SaveChanges();
        }

        public object GetStatistics()
        {
            // Trả về số lượng log, có thể mở rộng trả về ViewModel thống kê
            return new { Total = _context.SystemLogs.Count() };
        }
    }
}

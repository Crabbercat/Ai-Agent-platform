namespace AI_Agent_WebApp.Repositories.Interfaces
{
    public interface ISystemLogRepository
    {
        void LogAction(string action, int staffId);
        object GetStatistics(); // Có thể thay object bằng ViewModel thống kê cụ thể
    }
}

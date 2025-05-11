namespace AI_Agent_WebApp.Services.Interfaces
{
    public interface ISystemLogService
    {
        void LogAction(string action, int userId);
        object GetStatistics();
    }
}

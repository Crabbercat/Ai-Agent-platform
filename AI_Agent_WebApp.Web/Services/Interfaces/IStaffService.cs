using AI_Agent_WebApp.Models.Entities;

namespace AI_Agent_WebApp.Services.Interfaces
{
    public interface IStaffService
    {
        Staff GetStaffById(int id);
        object GetStatistics();
    }
}

using AI_Agent_WebApp.Models.Entities;

namespace AI_Agent_WebApp.Services.Interfaces
{
    public interface IStaffService
    {
        Staff GetStaffById(int id);
        object GetStatistics();
        IEnumerable<Staff> GetAllStaff();
        void ToggleStatus(int id);
        bool CreateStaff(Staff staff, string password);
        bool UpdateStaff(Staff staff);
        void DeleteStaff(int id);
        bool AddStaff(Staff staff);
    }
}

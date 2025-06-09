using AI_Agent_WebApp.Models.Entities;

namespace AI_Agent_WebApp.Repositories.Interfaces
{
    public interface IStaffRepository
    {
        Staff GetById(int id);
        object GetStatistics(); // Có thể thay object bằng ViewModel thống kê cụ thể
        void UpdateProfile(Staff staff);
        void UpdatePassword(int id, string newPasswordHash);
        IEnumerable<Staff> GetAll();
        void ToggleStatus(int id);
        bool CreateStaff(Staff staff, string password);
        bool UpdateStaff(Staff staff);
        void DeleteStaff(int id);
        bool AddStaff(Staff staff);
    }
}

namespace AI_Agent_WebApp.Repositories.Interfaces
{
    public interface IStaffRepository
    {
        Models.Entities.Staff GetById(int id);
        object GetStatistics(); // Có thể thay object bằng ViewModel thống kê cụ thể
        void UpdateProfile(Models.Entities.Staff staff);
        void UpdatePassword(int id, string newPasswordHash);
    }
}

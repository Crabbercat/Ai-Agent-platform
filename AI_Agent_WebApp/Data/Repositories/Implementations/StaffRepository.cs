using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Repositories.Interfaces;

namespace AI_Agent_WebApp.Repositories.Implementations
{
    public class StaffRepository : IStaffRepository
    {
        public Staff GetById(int id) => throw new NotImplementedException();
        public object GetStatistics() => throw new NotImplementedException();
        public void UpdateProfile(Staff staff) => throw new NotImplementedException();
        public void UpdatePassword(int id, string newPasswordHash) => throw new NotImplementedException();
    }
}

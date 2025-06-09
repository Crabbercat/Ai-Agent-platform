using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Repositories.Interfaces;
using AI_Agent_WebApp.Services.Interfaces;

namespace AI_Agent_WebApp.Services.Implementations
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _repo;
        public StaffService(IStaffRepository repo) { _repo = repo; }
        public Staff GetStaffById(int id) => _repo.GetById(id);
        public object GetStatistics() => _repo.GetStatistics();
        public IEnumerable<Staff> GetAllStaff()
        {
            return _repo.GetAll();
        }
        public void ToggleStatus(int id)
        {
            _repo.ToggleStatus(id);
        }

        public bool CreateStaff(Staff staff, string password)
        {
            return _repo.CreateStaff(staff, password);
        }

        public bool UpdateStaff(Staff staff)
        {
            return _repo.UpdateStaff(staff);
        }

        public void DeleteStaff(int id)
        {
            _repo.DeleteStaff(id);
        }

        public bool AddStaff(Staff staff)
        {
            return _repo.AddStaff(staff);
        }
    }
}

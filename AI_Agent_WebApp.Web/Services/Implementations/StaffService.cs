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
    }
}

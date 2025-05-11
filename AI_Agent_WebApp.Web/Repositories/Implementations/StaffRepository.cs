using AI_Agent_WebApp.Data;
using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AI_Agent_WebApp.Repositories.Implementations
{
    public class StaffRepository : IStaffRepository
    {
        private readonly ApplicationDbContext _context;
        public StaffRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Staff GetById(int id) => _context.Users.OfType<Staff>().FirstOrDefault(s => s.Id == id)!;
        public object GetStatistics()
        {
            // Trả về số lượng staff, có thể mở rộng trả về ViewModel thống kê
            return new { Total = _context.Users.OfType<Staff>().Count() };
        }
        public void UpdateProfile(Staff staff)
        {
            _context.Users.Update(staff);
            _context.SaveChanges();
        }
        public void UpdatePassword(int id, string newPasswordHash)
        {
            var staff = _context.Users.OfType<Staff>().FirstOrDefault(s => s.Id == id);
            if (staff != null)
            {
                staff.PasswordHash = newPasswordHash;
                _context.SaveChanges();
            }
        }
    }
}

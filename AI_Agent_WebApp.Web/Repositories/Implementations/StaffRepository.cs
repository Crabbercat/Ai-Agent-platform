using AI_Agent_WebApp.Data;
using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using AI_Agent_WebApp.Services.Implementations;

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
        public IEnumerable<Staff> GetAll()
        {
            return _context.Users.OfType<Staff>().ToList();
        }
        public void ToggleStatus(int id)
        {
            var staff = _context.Users.OfType<Staff>().FirstOrDefault(s => s.Id == id);
            if (staff != null)
            {
                var prop = staff.GetType().GetProperty("Status");
                if (prop != null && prop.PropertyType == typeof(bool))
                {
                    var value = prop.GetValue(staff);
                    bool current = value != null && (bool)value;
                    prop.SetValue(staff, !current);
                    _context.SaveChanges();
                }
            }
        }

        public bool CreateStaff(Staff staff, string password)
        {
            // Check for duplicate username or email
            if (_context.Users.Any(u => u.Username == staff.Username || u.Email == staff.Email))
                return false;
            staff.Role = "Staff";
            staff.Status = true;
            staff.CreatedAt = DateTime.Now;
            staff.PasswordHash = PasswordHasher.HashPassword(password);
            _context.Users.Add(staff);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateStaff(Staff staff)
        {
            var existing = _context.Users.OfType<Staff>().FirstOrDefault(s => s.Id == staff.Id);
            if (existing == null) return false;
            // Check for duplicate username or email (excluding self)
            if (_context.Users.Any(u => (u.Username == staff.Username || u.Email == staff.Email) && u.Id != staff.Id))
                return false;
            existing.FullName = staff.FullName;
            existing.Email = staff.Email;
            existing.Username = staff.Username;
            _context.SaveChanges();
            return true;
        }

        public void DeleteStaff(int id)
        {
            var staff = _context.Users.OfType<Staff>().FirstOrDefault(s => s.Id == id);
            if (staff != null)
            {
                _context.Users.Remove(staff);
                _context.SaveChanges();
            }
        }

        public bool AddStaff(Staff staff)
        {
            _context.Users.Add(staff);
            _context.SaveChanges();
            return true;
        }
    }
}

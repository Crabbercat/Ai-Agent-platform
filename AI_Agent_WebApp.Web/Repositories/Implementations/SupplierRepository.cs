using AI_Agent_WebApp.Data;
using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AI_Agent_WebApp.Repositories.Implementations
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDbContext _context;
        public SupplierRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Supplier GetById(int id)
        {
            var supplier = _context.Users.OfType<Supplier>().FirstOrDefault(s => s.Id == id) ?? throw new KeyNotFoundException($"Supplier with ID {id} was not found.");
            return supplier;
        }
        public IEnumerable<Supplier> GetAll() => _context.Users.OfType<Supplier>().ToList();
        public void UpdateProfile(Supplier supplier)
        {
            _context.Users.Update(supplier);
            _context.SaveChanges();
        }
        public void UpdatePassword(int id, string newPasswordHash)
        {
            var supplier = _context.Users.OfType<Supplier>().FirstOrDefault(s => s.Id == id);
            if (supplier != null)
            {
                supplier.PasswordHash = newPasswordHash;
                _context.SaveChanges();
            }
        }
        public void ToggleStatus(int id)
        {
            var supplier = _context.Users.OfType<Supplier>().FirstOrDefault(s => s.Id == id);
            if (supplier != null)
            {
                supplier.Status = !supplier.Status;
                _context.SaveChanges();
            }
        }
    }
}

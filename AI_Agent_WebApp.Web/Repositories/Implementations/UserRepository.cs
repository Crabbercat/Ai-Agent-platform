using AI_Agent_WebApp.Data;
using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AI_Agent_WebApp.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
        public User GetById(int id)
        {
            var user = _context.Users.Find(id) ?? throw new KeyNotFoundException($"User with ID {id} was not found.");
            return user;
        }
        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
        public void UpdatePassword(int id, string newPasswordHash)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                user.PasswordHash = newPasswordHash;
                _context.SaveChanges();
            }
        }
    }
}

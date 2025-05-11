using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Repositories.Interfaces;
using AI_Agent_WebApp.Services.Interfaces;

namespace AI_Agent_WebApp.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        public UserService(IUserRepository repo) { _repo = repo; }
        public void CreateUser(User user) => _repo.Create(user);
        public User GetUserById(int id) => _repo.GetById(id);
        public void UpdateProfile(User user) => _repo.Update(user);
        public void UpdatePassword(int id, string newPasswordHash) => _repo.UpdatePassword(id, newPasswordHash);
    }
}

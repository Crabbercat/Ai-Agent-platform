using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Repositories.Interfaces;

namespace AI_Agent_WebApp.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        public void Create(User user) => throw new NotImplementedException();
        public void Update(User user) => throw new NotImplementedException();
        public User GetById(int id) => throw new NotImplementedException();
        public void Delete(int id) => throw new NotImplementedException();
        public void UpdatePassword(int id, string newPasswordHash) => throw new NotImplementedException();
    }
}

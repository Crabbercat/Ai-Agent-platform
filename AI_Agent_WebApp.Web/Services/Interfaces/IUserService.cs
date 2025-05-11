using AI_Agent_WebApp.Models.Entities;

namespace AI_Agent_WebApp.Services.Interfaces
{
    public interface IUserService
    {
        void CreateUser(User user);
        User GetUserById(int id);
        void UpdateProfile(User user);
        void UpdatePassword(int id, string newPasswordHash);
    }
}

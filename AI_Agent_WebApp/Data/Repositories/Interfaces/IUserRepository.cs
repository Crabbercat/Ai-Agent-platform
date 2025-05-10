namespace AI_Agent_WebApp.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void Create(Models.Entities.User user);
        void Update(Models.Entities.User user);
        Models.Entities.User GetById(int id);
        void Delete(int id);
        void UpdatePassword(int id, string newPasswordHash);
    }
}

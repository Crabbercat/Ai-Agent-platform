namespace AI_Agent_WebApp.Repositories.Interfaces
{
    public interface IAgentRepository
    {
        // Truy vấn và thao tác dữ liệu Agent
        IEnumerable<Models.Entities.Agent> GetAll();
        Models.Entities.Agent GetById(int id);
        void Insert(Models.Entities.Agent agent);
        void Update(Models.Entities.Agent agent);
        void Delete(int id);
        void ToggleStatus(int id);
    }
}

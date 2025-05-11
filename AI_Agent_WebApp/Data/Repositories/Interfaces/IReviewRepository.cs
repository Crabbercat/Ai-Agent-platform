namespace AI_Agent_WebApp.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        IEnumerable<Models.Entities.Review> GetByAgentId(int agentId);
        void Create(Models.Entities.Review review);
    }
}

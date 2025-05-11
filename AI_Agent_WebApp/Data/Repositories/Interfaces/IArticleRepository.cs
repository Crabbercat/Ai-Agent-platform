namespace AI_Agent_WebApp.Repositories.Interfaces
{
    public interface IArticleRepository
    {
        IEnumerable<Models.Entities.Article> GetByAgentId(int agentId);
        IEnumerable<Models.Entities.Article> GetByAuthor(int authorId);
        void Create(Models.Entities.Article article);
        void Update(Models.Entities.Article article);
        void Delete(int id);
    }
}

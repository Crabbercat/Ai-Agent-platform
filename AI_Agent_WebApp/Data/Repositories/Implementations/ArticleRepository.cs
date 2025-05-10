using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Repositories.Interfaces;

namespace AI_Agent_WebApp.Repositories.Implementations
{
    public class ArticleRepository : IArticleRepository
    {
        public IEnumerable<Article> GetByAgentId(int agentId) => throw new NotImplementedException();
        public IEnumerable<Article> GetByAuthor(int authorId) => throw new NotImplementedException();
        public void Create(Article article) => throw new NotImplementedException();
        public void Update(Article article) => throw new NotImplementedException();
        public void Delete(int id) => throw new NotImplementedException();
    }
}

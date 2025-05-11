using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Repositories.Interfaces;
using AI_Agent_WebApp.Services.Interfaces;
using System.Collections.Generic;

namespace AI_Agent_WebApp.Services.Implementations
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _repo;
        public ArticleService(IArticleRepository repo) { _repo = repo; }
        public IEnumerable<Article> GetArticlesByAgent(int agentId) => _repo.GetByAgentId(agentId);
        public IEnumerable<Article> GetArticlesByAuthor(int authorId) => _repo.GetByAuthor(authorId);
        public void CreateArticle(Article article) => _repo.Create(article);
        public void UpdateArticle(Article article) => _repo.Update(article);
        public void DeleteArticle(int id) => _repo.Delete(id);
    }
}

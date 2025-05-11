using AI_Agent_WebApp.Models.Entities;
using System.Collections.Generic;

namespace AI_Agent_WebApp.Services.Interfaces
{
    public interface IArticleService
    {
        IEnumerable<Article> GetArticlesByAgent(int agentId);
        IEnumerable<Article> GetArticlesByAuthor(int authorId);
        void CreateArticle(Article article);
        void UpdateArticle(Article article);
        void DeleteArticle(int id);
    }
}

using AI_Agent_WebApp.Data;
using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AI_Agent_WebApp.Repositories.Implementations
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ApplicationDbContext _context;
        public ArticleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Article> GetByAgentId(int agentId) => _context.Articles
            .Include(a => a.Agent)
            .Include(a => a.User)
            .Where(a => a.AgentId == agentId)
            .ToList();
        public IEnumerable<Article> GetByAuthor(int userId) => _context.Articles
            .Include(a => a.Agent)
            .Include(a => a.User)
            .Where(a => a.UserId == userId)
            .ToList();
        public void Create(Article article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();
        }
        public void Update(Article article)
        {
            _context.Articles.Update(article);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var article = _context.Articles.Find(id);
            if (article != null)
            {
                _context.Articles.Remove(article);
                _context.SaveChanges();
            }
        }
    }
}

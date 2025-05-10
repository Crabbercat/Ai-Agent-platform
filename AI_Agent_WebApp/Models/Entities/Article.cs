using System;

namespace AI_Agent_WebApp.Models.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int AgentId { get; set; }
        public int AuthorId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

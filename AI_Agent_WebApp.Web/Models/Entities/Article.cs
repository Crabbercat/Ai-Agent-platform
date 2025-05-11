using System;

namespace AI_Agent_WebApp.Models.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Content { get; set; }
        public int AgentId { get; set; }
        public Agent? Agent { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

using System;

namespace AI_Agent_WebApp.Models.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public int Rating { get; set; }
        public int AgentId { get; set; }
        public Agent? Agent { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

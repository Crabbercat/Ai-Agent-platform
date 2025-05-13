using System;
using AI_Agent_WebApp.Models.Entities;

namespace AI_Agent_WebApp.Models.Entities
{
    public class Follow
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AgentId { get; set; }
        public DateTime FollowedAt { get; set; } = DateTime.UtcNow;
        public User? User { get; set; }
        public Agent? Agent { get; set; }
    }
}

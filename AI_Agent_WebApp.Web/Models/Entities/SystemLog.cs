using System;

namespace AI_Agent_WebApp.Models.Entities
{
    public class SystemLog
    {
        public int Id { get; set; }
        public required string Action { get; set; }
        public DateTime Timestamp { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}

using System;

namespace AI_Agent_WebApp.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public string? FullName { get; set; }
        public required string Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

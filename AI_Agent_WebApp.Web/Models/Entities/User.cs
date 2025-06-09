using System;

namespace AI_Agent_WebApp.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; } // Để nullable, không required, tránh lỗi khi tạo staff
        public string? FullName { get; set; }
        public required string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; } // Add this line for TPH status
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace AI_Agent_WebApp.Models.Entities
{
    public class Agent
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int PaymentTypeId { get; set; }
        public PaymentType? PaymentType { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ImagePath { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public string? Url { get; set; } // Link website của AI (nullable)
        public ICollection<Follow>? Follows { get; set; } // Navigation property để đếm số follow
        public ICollection<Article>? Articles { get; set; } // Navigation property for articles
    }
}

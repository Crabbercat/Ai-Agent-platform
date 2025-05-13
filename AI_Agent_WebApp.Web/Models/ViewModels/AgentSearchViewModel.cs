using System.Collections.Generic;
using AI_Agent_WebApp.Models.Entities;

namespace AI_Agent_WebApp.Models.ViewModels
{
    public class AgentSearchViewModel
    {
        public string? SearchTerm { get; set; }
        public int? CategoryId { get; set; }
        public int? PaymentTypeId { get; set; }
        public int Page { get; set; } = 1;
        public int TotalPages { get; set; } = 1;
        public List<Category> Categories { get; set; } = new();
        public List<PaymentType> PaymentTypes { get; set; } = new();
        public List<Agent> Agents { get; set; } = new();
    }
}

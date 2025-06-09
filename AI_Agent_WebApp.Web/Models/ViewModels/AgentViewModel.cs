using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AI_Agent_WebApp.Models.ViewModels
{
    public class AgentViewModel
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public int PaymentTypeId { get; set; }
        public string? Url { get; set; }
        public string? ImagePath { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
